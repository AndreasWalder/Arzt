using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arzt.BAL;

namespace Arzt.Services
{
    public class PatientServices
    {
        #region Property
        private readonly ArztContext _appDBContext;
        #endregion

        #region Constructor
        public PatientServices(ArztContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Patients
        public async Task<List<Patient>> GetAllAsync()
        {
            return await _appDBContext.Patients.ToListAsync();
        }
        #endregion

        #region Insert Patient
        public async Task<bool> InsertAsync(Patient patient)
        {
            await _appDBContext.Patients.AddAsync(patient);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Patient by Id
        public async Task<Patient> GetByIdAsync(int Id)
        {
            Patient patient = await _appDBContext.Patients.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return patient;
        }
        #endregion

        #region Update Patient
        public async Task<bool> UpdateAsync(Patient patient)
        {
            _appDBContext.Patients.Update(patient);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Patient
        public async Task<bool> DeleteAsync(Patient patient)
        {
            _appDBContext.Remove(patient);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
