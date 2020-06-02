using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.Core.Domain;

namespace Veam.EMS.EmpBasic
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeListQueryVM>> GetAllEmpAsync();
        Task< Employee> GetEmployee(long Id);
        Task<Employee> GetEmployeeByCardNo(string IDCardNo);
    }

    public interface IEmployeeReadService
    {
        Task<IEnumerable<subsideryVM>> GetSubsidery();
         
    }
    public class subsideryVM
    {
        public int ID { get; set; }
        public string name { get; set; }
    }
}
