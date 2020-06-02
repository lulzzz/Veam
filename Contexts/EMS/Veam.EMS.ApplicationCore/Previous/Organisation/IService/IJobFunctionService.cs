using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Models;

namespace Veam.EMS.ApplicationCore.Interfaces.Services
{
    public interface IJobFunctionService
    {
        Task<JobFunctionModel> GetByIdAsync(int id);
        Task<List<JobFunctionModel>> GetAllAsync();
        Task<List<JobFunctionModel>> GetByNameAsync(string name);
        Task<List<JobFunctionModel>> GetBySectionIdAsync(int sectionId);
        Task AddAsync(JobFunctionModel model);
        Task UpdateAsync(JobFunctionModel model);
        Task DeleteAsync(int id);
    }
}
