using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Helper;
using Veam.EMS.ApplicationCore.Models;

namespace Veam.EMS.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetAllAsync();
        Task<List<EmployeeModel>> GetByNameAsync(string name);
        Task<List<EmployeeModel>> GetAsync(EmployeeFilter filter);
        Task<EmployeeModel> GetByEmployeeIdAsync(string employeeId);
        Task<EmployeeModel> GetByEmployeeIdWithDetailAsync(string employeeId);
        Task<int> CountTotalEmployeeAsync();
        Task<bool> ExistsAsync(string employeeId);
        Task<EmployeeModel> AddAsync(EmployeeModel model);
        Task UpdateAsync(EmployeeModel model);
        Task DeleteAsync(int id);
    }
}
