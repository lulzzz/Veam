using Veam.EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Veam.EMS.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeListService
    {
        Task<List<EmployeeListModel>> GetAllAsync();
    }
}
