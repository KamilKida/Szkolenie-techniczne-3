using HotelWebAPI.Reservations.Dtos;
using HotelWebAPI.Reservations.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelWebAPI.Reservations.Services
{
    public class DiscountService
    {
        private readonly ReservationsDbContext _dbContext;

        public DiscountService(ReservationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Discount>> GetAll()
        {
            return await _dbContext.Discounts.ToArrayAsync();
        }

        public async Task<Tuple<Discount, string>> Add(AddDiscountDto dto)
        {
            if (dto.RequiredAmountOfVisits <= 0 && !dto.IsPromotion)
                return new Tuple<Discount, string>(null, "Amount of visits must be greater than 0.");

            if (dto.DiscountAmount <= 0)
                return new Tuple<Discount, string>(null, "Discount amount must be greater than 0.");

            if (!dto.IsPromotion)
            {
                var exists = await _dbContext.Discounts.AnyAsync(d => !d.IsPromotion && d.RequiredAmountOfVisits == dto.RequiredAmountOfVisits);
                if (exists)
                    return new Tuple<Discount, string>(null, "Discount with this required amount of visits already exists.");
            }

            if (dto.IsPromotion)
            {
                var exists = await _dbContext.Discounts.AnyAsync(d => d.IsPromotion && d.DiscountAmount == dto.DiscountAmount);
                if (exists)
                    return new Tuple<Discount, string>(null, "Promotion with this discount amount already exists.");
            }

            var newDiscount = new Discount
            {
                RequiredAmountOfVisits = dto.RequiredAmountOfVisits,
                DiscountAmount = dto.DiscountAmount,
                IsPromotion = dto.IsPromotion,
                IsActive = dto.IsActive
            };

            await _dbContext.Discounts.AddAsync(newDiscount);
            await _dbContext.SaveChangesAsync();

            return new Tuple<Discount, string>(newDiscount, null);
        }

        public async Task<Tuple<Discount, string>> Edit(EditDiscountDto dto)
        {
            var discountToEdit = await _dbContext.Discounts
                .FirstOrDefaultAsync(d => d.Id == dto.Id);

            if (discountToEdit is null)
                return new Tuple<Discount, string>(null, "Discount not found.");

            if (dto.RequiredAmountOfVisits != null)
            {
                if (dto.RequiredAmountOfVisits <= 0)
                    return new Tuple<Discount, string>(null, "Amount of visits must be greater than 0.");
                discountToEdit.RequiredAmountOfVisits = dto.RequiredAmountOfVisits.Value;
            }

            if (dto.DiscountAmount != null)
            {
                if (dto.DiscountAmount <= 0)
                    return new Tuple<Discount, string>(null, "Discount amount must be greater than 0.");
                discountToEdit.DiscountAmount = dto.DiscountAmount.Value;
            }

            if (dto.IsPromotion != null)
                discountToEdit.IsPromotion = dto.IsPromotion.Value;

            if (dto.IsActive != null)
                discountToEdit.IsActive = dto.IsActive.Value;

            if (discountToEdit.IsPromotion)
            {
                var promotionExists = await _dbContext.Discounts
                    .AnyAsync(d => d.Id != discountToEdit.Id && d.IsPromotion && d.DiscountAmount == discountToEdit.DiscountAmount);

                if (promotionExists)
                    return new Tuple<Discount, string>(null, "Another promotion with this discount amount already exists.");
            }
            else
            {
                var visitDiscountExists = await _dbContext.Discounts
                    .AnyAsync(d => d.Id != discountToEdit.Id && !d.IsPromotion && d.RequiredAmountOfVisits == discountToEdit.RequiredAmountOfVisits);

                if (visitDiscountExists)
                    return new Tuple<Discount, string>(null, "Another discount with this required amount of visits already exists.");
            }

            _dbContext.Discounts.Update(discountToEdit);
            await _dbContext.SaveChangesAsync();

            return new Tuple<Discount, string>(discountToEdit, null);
        }

        public async Task<bool> Delete(int id)
        {
            var discountToDelete = await _dbContext.Discounts
                .FirstOrDefaultAsync(d => d.Id == id);

            if (discountToDelete == null)
                return false;

            _dbContext.Discounts.Remove(discountToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
