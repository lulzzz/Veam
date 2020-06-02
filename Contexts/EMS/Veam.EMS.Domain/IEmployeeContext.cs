using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Veam.EMS.Domain
{
    public interface IEmployeeContext
    {
        DbSet<AttendanceC> AttendanceC { get; set; }
        DbSet<Employee> Employee { get; set; }
     

        DbSet<EmployeeAddress> EmployeeAddress { get; set; }
        DbSet<EmployeeEducation> EmployeeEducation { get; set; }
        DbSet<EmployeeImage> EmployeeImage { get; set; }
        DbSet<EmployeeLocation> EmployeeLocation { get; set; }
        DbSet<EmployeeState> EmployeeState { get; set; }
        DbSet<EmployeeSkills> EmployeSkills { get; set; }
      

        DbSet<HireInfo> HireInfo { get; set; }
        DbSet<ResignInfo> ResignInfo { get; set; }
       

        DbSet<MasterDepartment> MasterDepartment { get; set; }
        DbSet<EducationDegree> MasterEducationDegree { get; set; }
     //   DbSet<MasterEducationMajor> MasterEducationMajor { get; set; }
        DbSet<MasterJobFunction> MasterJobFunction { get; set; }
        DbSet<MasterJobPosition> MasterJobPosition { get; set; }
        DbSet<MasterLevel> MasterLevel { get; set; }
        //DbSet<MasterLocation> MasterLocation { get; set; }
        //DbSet<MasterLocationGroup> MasterLocationGroup { get; set; }
        //DbSet<MasterRoute> MasterRoute { get; set; }
        DbSet<MasterSection> MasterSection { get; set; }
        DbSet<MasterShift> MasterShift { get; set; }
        DbSet<MasterShiftCalendar> MasterShiftCalendar { get; set; }
        DbSet<MasterSkill> MasterSkill { get; set; }
        DbSet<MasterSkillGroup> MasterSkillGroup { get; set; }
        DbSet<MasterSkillType> MasterSkillType { get; set; }
        DbSet<EmployeeContact> EmployeeContact { get; set; }
        DbSet< EmployeeDocuments> EmployeeDocument { get; set; }
        DbSet< EmployeeGovtIds> EmployeeGovtIds { get; set; }
     

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}