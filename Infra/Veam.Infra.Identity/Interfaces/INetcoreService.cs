using Microsoft.AspNetCore.Identity;
using Veam.Models;
using System.Threading.Tasks;

namespace Veam.Services
{
    public interface INetcoreService
    {
       
        Task<bool> IsAccountActivatedAsync(string email, UserManager<ApplicationUser> userManager);

        Task UpdateRoles(ApplicationUser appUser, ApplicationUser currentUserLogin);

        Task CreateDefaultSuperAdmin();
    }
}
