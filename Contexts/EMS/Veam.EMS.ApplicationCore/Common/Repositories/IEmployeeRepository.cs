using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.Domain;

namespace Veam.EMS.ApplicationCore.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetProfileAsync();
    }
}
