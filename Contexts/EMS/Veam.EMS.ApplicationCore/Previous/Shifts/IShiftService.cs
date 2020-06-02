using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Models;

namespace Veam.EMS.ApplicationCore.Interfaces.Services
{
    public interface IShiftService
    {
        Task<ShiftModel> GetByIdAsync(int id);
        Task<List<ShiftModel>> GetByTimeAsync(TimeSpan currentTime);
        Task<List<ShiftModel>> GetAllAsync();
        Task<List<ShiftModel>> GetByNameAsync(string name);
        Task AddAsync(ShiftModel model);
        Task UpdateAsync(ShiftModel model);
        Task DeleteAsync(int id);
    }
}
