using System.Collections.Generic;
using System.Threading.Tasks;
using GymMe.Models;
using GymMe.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymMe.Handlers
{
    public class UserHandler : IUserHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.Users.GetAll().ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _unitOfWork.Users.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _unitOfWork.Users.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _unitOfWork.Users.DeleteAsync(id);
        }
    }
}
