using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Models;

namespace Veam.EMS.ApplicationCore.Interfaces.Services
{
    public interface IJobPositionService
    {
        Task<JobPositionModel> GetByIdAsync(int id);
        Task<List<JobPositionModel>> GetAllAsync();
        Task<List<JobPositionModel>> GetByNameAsync(string name);
        Task AddAsync(JobPositionModel model);
        Task UpdateAsync(JobPositionModel model);
        Task DeleteAsync(int id);
    }
}
