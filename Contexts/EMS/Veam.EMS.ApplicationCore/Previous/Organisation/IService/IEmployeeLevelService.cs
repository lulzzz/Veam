using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Models;

namespace Veam.EMS.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeLevelService
    {
        Task<EmployeeLevelModel> GetByIdAsync(int id);
        Task<List<EmployeeLevelModel>> GetAllAsync();
        Task<List<EmployeeLevelModel>> GetByNameAsync(string name);
        Task AddAsync(EmployeeLevelModel model);
        Task UpdateAsync(EmployeeLevelModel model);
        Task DeleteAsync(int id);
    }
}
