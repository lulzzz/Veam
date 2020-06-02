using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Veam.Data;
using Veam.Models;

namespace Veam.Services
{
    public class NetcoreService : INetcoreService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
       
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRoles _roles;
        private readonly SuperAdminDefaultOptions _superAdminDefaultOptions;

        public NetcoreService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
          
            SignInManager<ApplicationUser> signInManager,
            IRoles roles,
            IOptions<SuperAdminDefaultOptions> superAdminDefaultOptions)
        {
            _userManager = userManager;
            _roleManager = roleManager;
           
            _signInManager = signInManager;
            _roles = roles;
            _superAdminDefaultOptions = superAdminDefaultOptions.Value;
        }

      
        public async Task<bool> IsAccountActivatedAsync(string email, UserManager<ApplicationUser> userManager)
        {
            bool result = false;
            try
            {
                var user = await userManager.FindByNameAsync(email);
                if (user != null)
                {
                    //Add this to check if the email was confirmed.
                    if (await userManager.IsEmailConfirmedAsync(user))
                    {
                        result = true;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public async Task UpdateRoles(ApplicationUser appUser,
            ApplicationUser currentLoginUser)
        {
            try
            {
                await _roles.UpdateRoles(appUser, currentLoginUser);

                //so no need to manually re-signIn to make roles changes effective
                if (currentLoginUser.Id == appUser.Id)
                {
                    await _signInManager.SignInAsync(appUser, false);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreateDefaultSuperAdmin()
        {
            try
            {
                ApplicationUser superAdmin = new ApplicationUser();
                superAdmin.Email = _superAdminDefaultOptions.Email;
                superAdmin.UserName = superAdmin.Email;
                superAdmin.EmailConfirmed = true;
                superAdmin.isSuperAdmin = true;

                Type t = superAdmin.GetType();
                foreach (System.Reflection.PropertyInfo item in t.GetProperties())
                {
                    if (item.Name.Contains("Role"))
                    {
                        item.SetValue(superAdmin, true);
                    }
                }

                await _userManager.CreateAsync(superAdmin, _superAdminDefaultOptions.Password);

                //loop all the roles and then fill to SuperAdmin so he become powerfull
                foreach (var item in typeof(Veam.MVC.Pages).GetNestedTypes())
                {
                    var roleName = item.Name;
                    if (!await _roleManager.RoleExistsAsync(roleName)) { await _roleManager.CreateAsync(new IdentityRole(roleName)); }

                    await _userManager.AddToRoleAsync(superAdmin, roleName);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
