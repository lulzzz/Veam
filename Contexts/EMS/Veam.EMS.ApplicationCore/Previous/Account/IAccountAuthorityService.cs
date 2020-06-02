using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Models;

namespace Veam.EMS.ApplicationCore.Interfaces.Services
{
    public interface IAccountAuthorityService
    {
        Task<AccountAuthorityModel> GetByIdAsync(int id);
        Task<List<AccountAuthorityModel>> GetAllAsync();
        Task AddAsync(AccountAuthorityModel model);
    }
}
