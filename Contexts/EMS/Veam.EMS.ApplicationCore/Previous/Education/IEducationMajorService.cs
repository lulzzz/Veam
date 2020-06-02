using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Models;

namespace Veam.EMS.ApplicationCore.Interfaces.Services
{
    public interface IEducationMajorService
    {
        Task<EducationMajorModel> GetByIdAsync(int id);
        Task<List<EducationMajorModel>> GetAllAsync();
        Task<List<EducationMajorModel>> GetByNameAsync(string name);
        Task AddAsync(EducationMajorModel model);
        Task UpdateAsync(EducationMajorModel model);
        Task DeleteAsync(int id);
    }
}
