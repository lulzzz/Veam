using Veam.EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Veam.EMS.ApplicationCore.Interfaces.Services
{
    public interface IEmployeePasswordService
    {
        Task<EmployeePasswordModel> GetByEmployeeId(string employeeId);
        Task<EmployeePasswordModel> AddAsync(EmployeePasswordModel model);
        Task UpdateAsync(EmployeePasswordModel model);
    }
}
