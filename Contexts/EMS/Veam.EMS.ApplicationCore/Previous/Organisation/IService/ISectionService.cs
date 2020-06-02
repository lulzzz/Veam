using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Models;

namespace Veam.EMS.ApplicationCore.Interfaces.Services
{
    public interface ISectionService
    {
        Task<SectionModel> GetByIdAsync(int id);
        Task<List<SectionModel>> GetAllAsync();
        Task<List<SectionModel>> GetByNameAsync(string name);
        Task<List<SectionModel>> GetByDepartmentIdAsync(int departmentId);
        Task AddAsync(SectionModel model);
        Task UpdateAsync(SectionModel model);
        Task DeleteAsync(int id);
    }
}
