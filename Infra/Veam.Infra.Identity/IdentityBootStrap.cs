using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Veam.Data;
using Veam.Models;
using Veam.Services;

namespace Veam.Identity
{
    public static class IdentityBootStrap
    {
        public static IServiceCollection AddCustomIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Get Identity Default Options
            IConfigurationSection identityDefaultOptionsConfigurationSection = configuration.GetSection("IdentityDefaultOptions");

            services.Configure<IdentityDefaultOptions>(identityDefaultOptionsConfigurationSection);

            var identityDefaultOptions = identityDefaultOptionsConfigurationSection.Get<IdentityDefaultOptions>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = identityDefaultOptions.PasswordRequireDigit;
                options.Password.RequiredLength = identityDefaultOptions.PasswordRequiredLength;
                options.Password.RequireNonAlphanumeric = identityDefaultOptions.PasswordRequireNonAlphanumeric;
                options.Password.RequireUppercase = identityDefaultOptions.PasswordRequireUppercase;
                options.Password.RequireLowercase = identityDefaultOptions.PasswordRequireLowercase;
                options.Password.RequiredUniqueChars = identityDefaultOptions.PasswordRequiredUniqueChars;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(identityDefaultOptions.LockoutDefaultLockoutTimeSpanInMinutes);
                options.Lockout.MaxFailedAccessAttempts = identityDefaultOptions.LockoutMaxFailedAccessAttempts;
                options.Lockout.AllowedForNewUsers = identityDefaultOptions.LockoutAllowedForNewUsers;

                // User settings
                options.User.RequireUniqueEmail = identityDefaultOptions.UserRequireUniqueEmail;

                // email confirmation require
                options.SignIn.RequireConfirmedEmail = identityDefaultOptions.SignInRequireConfirmedEmail;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // cookie settings
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly = identityDefaultOptions.CookieHttpOnly;
             //   options.Cookie.Expiration = TimeSpan.FromDays(identityDefaultOptions.CookieExpiration);
                options.LoginPath = identityDefaultOptions.LoginPath; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = identityDefaultOptions.LogoutPath; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = identityDefaultOptions.AccessDeniedPath; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = identityDefaultOptions.SlidingExpiration;
            });

            // Add custom role services
            services.AddTransient<IRoles, Roles>();

            // Add DI for Identity and superadmin defaults
            services.AddTransient<INetcoreService, NetcoreService>();
            // Get Super Admin Default options
            services.Configure<SuperAdminDefaultOptions>(configuration.GetSection("SuperAdminDefaultOptions"));
            return services;
        }
    }
   
}
