using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arzt.BAL;

namespace Arzt.Services
{
    public class UserServices
    {
        #region Property
        private readonly ArztContext _appDBContext;
        #endregion

        #region Constructor
        public UserServices(ArztContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of User
        public async Task<List<User>> GetAllAsync()
        {
            return await _appDBContext.Users.ToListAsync();
        }
        #endregion

        #region Insert User
        public async Task<bool> InsertAsync(User user)
        {
            await _appDBContext.Users.AddAsync(user);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get User by Id
        public async Task<User> GetByIdAsync(int Id)
        {
            User user = await _appDBContext.Users.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return user;
        }
        #endregion

        #region Update User
        public async Task<bool> UpdateAsync(User user)
        {
            _appDBContext.Users.Update(user);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region DeleteUser
        public async Task<bool> DeleteAsync(User user)
        {
            _appDBContext.Remove(user);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
