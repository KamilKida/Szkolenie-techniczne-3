using HotelWebAPI.Main.Dtos;
using HotelWebAPI.Main.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelWebAPI.Main.Services
{
    public class UserService
    {
        private readonly ReservationsDbContext _dbContext;

        public UserService(ReservationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Add(AddUserDto dto)
        {
            var newUser = new User()
            {
                FullName = dto.FullName,
                AmountOfVisits = 0,
                Email = dto.Email,
                Password = dto.Password
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> Edit(EditUserDto dto)
        {
            var userToEdit = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == dto.Id);

            if(userToEdit == null) return default;

            if(userToEdit.FullName != dto.FullName && !string.IsNullOrEmpty(dto.FullName)) userToEdit.FullName = dto.FullName;
            if(userToEdit.Email != dto.Email && !string.IsNullOrEmpty(dto.Email)) userToEdit.Email = dto.Email;
            if(userToEdit.Password != dto.Password && !string.IsNullOrEmpty(dto.Password)) userToEdit.Password = dto.Password;

            _dbContext.Update(userToEdit);
            await _dbContext.SaveChangesAsync();

            return userToEdit;

        }

        public async Task<bool> Delete(int id)
        {
            var userToDelete = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (userToDelete == null) return false;

            _dbContext.Users.Remove(userToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
