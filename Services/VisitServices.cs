using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arzt.BAL;

namespace Arzt.Services
{
    public class VisitServices
    {
        #region Property
        private readonly ArztContext _appDBContext;
        #endregion

        #region Constructor
        public VisitServices(ArztContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Visits
        public async Task<List<Visit>> GetAllAsync()
        {
            return await _appDBContext.Visits.ToListAsync();
        }
        #endregion

        #region Insert Visit
        public async Task<bool> InsertAsync(Visit visit)
        {
            await _appDBContext.Visits.AddAsync(visit);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Visit by Id
        public async Task<Visit> GetByIdAsync(int Id)
        {
            Visit visit = await _appDBContext.Visits.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return visit;
        }
        #endregion

        #region Update Visit
        public async Task<bool> UpdateAsync(Visit visit)
        {
            _appDBContext.Visits.Update(visit);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Visit
        public async Task<bool> DeleteAsync(Visit visit)
        {
            _appDBContext.Remove(visit);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
