using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arzt.BAL;

namespace Arzt.Services
{
    public class MedicationServices
    {
        #region Property
        private readonly ArztContext _appDBContext;
        #endregion

        #region Constructor
        public MedicationServices(ArztContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Medication
        public async Task<List<Medication>> GetAllAsync()
        {
            return await _appDBContext.Medications.ToListAsync();
        }
        #endregion

        #region Insert Medication
        public async Task<bool> InsertAsync(Medication medication)
        {
            await _appDBContext.Medications.AddAsync(medication);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Medication by Id
        public async Task<Medication> GetByIdAsync(int Id)
        {
            Medication medication = await _appDBContext.Medications.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return medication;
        }
        #endregion

        #region Update Medication
        public async Task<bool> UpdateAsync(Medication medication)
        {
            _appDBContext.Medications.Update(medication);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Medication
        public async Task<bool> DeleteAsync(Medication medication)
        {
            _appDBContext.Remove(medication);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
