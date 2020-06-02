using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Models;

namespace Veam.EMS.ApplicationCore.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentModel> GetByIdAsync(int id);
        Task<List<DepartmentModel>> GetAllAsync();
        Task<List<DepartmentModel>> GetByNameAsync(string name);
        Task AddAsync(DepartmentModel model);
        Task UpdateAsync(DepartmentModel model);
        Task DeleteAsync(int id);
    }
}
