using EMS.Persistance.Repositories;
using EMS.WebCore.Interfaces;
using EMS.WebCore.Services;
using Microsoft.Extensions.DependencyInjection;
using Veam.EMS.ApplicationCore.Interfaces.Repositories;
using Veam.EMS.ApplicationCore.Interfaces.Services;
using Veam.EMS.ApplicationCore.Services;

namespace Veam.EMS
{
    public static class EMSBootstap
    {
        public static IServiceCollection AddEMSService(this IServiceCollection services)
        {
           
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthorityService, AuthorityService>();
            services.AddScoped<IAccountAuthorityService, AccountAuthorityService>();

            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IJobPositionService, JobPositiobService>();
            services.AddScoped<IJobFunctionService, JobFunctionService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IShiftCalendarService, ShiftCalendarService>();
            services.AddScoped<IEmployeeLevelService, EmployeeLevelService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeListService, EmployeeListService>();
            services.AddScoped<IEmployeeStateService, EmployeeStateService>();
            services.AddScoped<IEmployeeAddressService, EmployeeAddressService>();
            services.AddScoped<IEmployeeImageService, EmployeeImageService>();
            services.AddScoped<IEmployeeSkillService, EmployeeSkillService>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<IBusStationService, BusStationService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ISkillGroupService, SkillGroupService>();
            services.AddScoped<ISkillTypeService, SkillTypeService>();

            services.AddScoped<IAuthenService, AuthenService>();
            services.AddScoped<IEmployeeDetailService, EmployeeDetailService>();
            services.AddScoped<IEducationDegreeService, EducationDegreeService>();
            services.AddScoped<IEducationMajorService, EducationMajorService>();

            services.AddScoped<IEmployeeViewModelService, EmployeeViewModelService>();
            services.AddScoped<IProfileViewModelService, ProfileViewModelService>();
            services.AddScoped<IDashboardViewModelService, DashboardViewModelService>();
            return services;
        }
    }
}
