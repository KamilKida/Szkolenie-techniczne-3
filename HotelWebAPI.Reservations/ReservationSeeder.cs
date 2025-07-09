using HotelWebAPI.Reservations.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelWebAPI.Reservations
{
    public class ReservationSeeder
    {
        private readonly ReservationsDbContext _dbContext;

        public ReservationSeeder(ReservationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Rooms.Any())
                {
                    var rooms =  GetRooms();
                    _dbContext.Rooms.AddRange(rooms);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Discounts.Any())
                {
                    var discounts = GetDiscounts();
                    _dbContext.Discounts.AddRange(discounts);
                    _dbContext.SaveChanges();
                }
            }

        }

        private IEnumerable<Room> GetRooms()
        {
            var rooms = new List<Room>()
            {
                new Room()
                {
                    Price = 50,
                    Available = true
                },
                new Room()
                {
                    Price = 50,
                    Available = true
                },
                new Room()
                {
                    Price = 50,
                    Available = true
                },
                new Room()
                {
                    Price = 150,
                    Available = true
                },
                new Room()
                {
                    Price = 150,
                    Available = true
                },
                new Room()
                {
                    Price = 150,
                    Available = true
                },
                new Room()
                {
                    Price = 500,
                    Available = true
                },
                new Room()
                {
                    Price = 500,
                    Available = true
                }
            };

            return rooms;
        }

        private IEnumerable<Discount> GetDiscounts()
        {
            var discounts = new List<Discount>()
            {
                new Discount()
                {
                    RequiredAmountOfVisits = 10,
                    DiscountAmount = 10,
                },
                new Discount()
                {
                    RequiredAmountOfVisits = 100,
                    DiscountAmount = 25
                }
            };

            return discounts;
        }
    }
}
                