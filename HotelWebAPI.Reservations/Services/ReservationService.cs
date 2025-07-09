using HotelWebAPI.Reservations.Dtos;
using HotelWebAPI.Reservations.Entities;
using HotelWebAPI.Reservations.Resolver;
using HotelWebAPI.Reservations.Dtos;
using HotelWebAPI.Reservations.Entities;
using Microsoft.EntityFrameworkCore;
using HotelWebAPI.Payments.Dtos;

namespace HotelWebAPI.Reservations.Services
{
    public class ReservationService
    {
        private readonly ReservationsDbContext _dbContext;
        private readonly PaymentResolver _paymentResolver;

        public ReservationService(ReservationsDbContext dbContext, PaymentResolver paymentResolver)
        {
            _dbContext = dbContext;
            _paymentResolver = paymentResolver;
        }

        public async Task<Tuple<UserReservation, string>> Add(AddReservationDto dto)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == dto.UserId);

            if (user == null)
                return new Tuple<UserReservation, string>(null, "User not found.");

            var room = await _dbContext.Rooms
                .FirstOrDefaultAsync(r => r.Id == dto.RoomId);

            if (room == null)
                return new Tuple<UserReservation, string>(null, "Room not found.");

            if (!room.Available)
                return new Tuple<UserReservation, string>(null, "Room not available.");

            if (dto.ReservedFrom > dto.ReservedTo)
                return new Tuple<UserReservation, string>(null, "Reservation start date cannot be later than end date.");

            var amountOfDays = (dto.ReservedTo - dto.ReservedFrom).Days;

            var newReservation = new UserReservation()
            {
                UserId = user.Id,
                RoomId = room.Id,
                ReservedFrom = dto.ReservedFrom,
                ReservedTo = dto.ReservedTo,
                Price = room.Price * amountOfDays,
            };

            var userDiscounts = await _dbContext.Discounts
                .Where(d => d.RequiredAmountOfVisits <= user.AmountOfVisits)
                .ToListAsync();

            var promotion = await _dbContext.Discounts
                .Where(d => d.IsPromotion && d.IsActive)
                .FirstOrDefaultAsync();

            Discount biggestUserDiscount = null;
            if (userDiscounts is not null && userDiscounts.Count > 0)
                biggestUserDiscount = userDiscounts.OrderByDescending(d => d.RequiredAmountOfVisits).First();

            if (biggestUserDiscount == null && promotion != null)
            {
                newReservation.DiscountId = promotion.Id;
            }
            else if (biggestUserDiscount != null && promotion == null)
            {
                newReservation.DiscountId = biggestUserDiscount.Id;
            }
            else if (biggestUserDiscount != null && promotion != null)
            {
                newReservation.DiscountId = biggestUserDiscount.DiscountAmount > promotion.DiscountAmount
                    ? biggestUserDiscount.Id
                    : promotion.Id;
            }

            room.Available = false;

            await _dbContext.UserReservations.AddAsync(newReservation);
            _dbContext.Update(room);
            await _dbContext.SaveChangesAsync();

            return new Tuple<UserReservation, string>(newReservation,null);
        }

        public async Task<Tuple<bool, string>> ConfirmReservation(int id)
        {
            var reservation = await _dbContext.UserReservations
                    .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
                return new Tuple<bool, string>(false, "Reservation not found.");

            if (reservation.Confirmed)
                return new Tuple<bool, string>(false, "Reservation already confirmed.");

            var newPayment = new AddPaymentDto
            {
                ReservationId = reservation.Id,
                Amount = reservation.Price
            };

            var paymentResult = await _paymentResolver.ResolveFor<AddPaymentDto>(newPayment, "hotelPayment/payment/add");

            if (string.IsNullOrEmpty(paymentResult))
            {
                return new Tuple<bool, string>(false, "Payment did not get saved.");
            }

            var newInvoice = new AddInvoiceDto()
            {
                PaymentId = reservation.Id,
                UserId = reservation.UserId
            };

            var invoiceResult = await _paymentResolver.ResolveFor<AddInvoiceDto>(newInvoice, "hotelPayment/invoice/add");

            reservation.Confirmed = true;
            _dbContext.Update(reservation);
            await _dbContext.SaveChangesAsync();

            return new Tuple<bool, string>(true, paymentResult);
        }

        public async Task<Tuple<bool, string>> CancelReservation(AddRefundDto dto)
        {
            var reservation = await _dbContext.UserReservations
                    .Include(r => r.Room)
                    .FirstOrDefaultAsync(r => r.Id == dto.ReservationId);

            if (reservation == null)
                return new Tuple<bool, string>(false, "Reservation not found.");

            if (reservation.Room is not null)
                reservation.Room.Available = true;

            _dbContext.UserReservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();

            if (reservation.Confirmed)
            {
                var refundResult = await _paymentResolver.ResolveFor<AddRefundDto>(dto, "hotelPayment/refund/add");

                if (refundResult is null)
                    return new Tuple<bool, string>(false, "Refund did not get added.");

                return new Tuple<bool, string>(true, refundResult);
            }
            else
            {
                return new Tuple<bool, string>(true, null);
            }
        }
    }
}
