using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arzt.BAL;
using System.Linq;

namespace Arzt.Services
{
    public class VisitMedicationServices
    {
        #region Property
        private readonly ArztContext _appDBContext;
        #endregion

        #region Constructor
        public VisitMedicationServices(ArztContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of VisitMedications
        public async Task<List<VisitMedication>> GetAllAsync()
        {
            return await _appDBContext.VisitMedications
                .Include(x => x.Visit)
                .ThenInclude(x => x.Patient)
                .ThenInclude(x => x.Visits)
                .ThenInclude(x => x.VisitMedications)
                .ThenInclude(x => x.Medication)
                .OrderByDescending(x => x.Visit.DateOfVisit).ToListAsync();
        }
        #endregion

        #region Insert VisitMedication
        public async Task<bool> InsertAsync(VisitMedication visitMedication)
        {
            await _appDBContext.VisitMedications.AddAsync(visitMedication);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get VisitMedication by Id
        public async Task<VisitMedication> GetByIdAsync(int Id)
        {
            VisitMedication visitMedication = await _appDBContext.VisitMedications.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return visitMedication;
        }
        #endregion

        #region Update VisitMedication
        public async Task<bool> UpdateAsync(VisitMedication visitMedication)
        {
            _appDBContext.VisitMedications.Update(visitMedication);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete VisitMedication
        public async Task<bool> DeleteAsync(VisitMedication visitMedication)
        {
            _appDBContext.Remove(visitMedication);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
