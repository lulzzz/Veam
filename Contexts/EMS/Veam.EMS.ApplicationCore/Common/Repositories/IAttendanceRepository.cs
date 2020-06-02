using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Helper;
using Veam.EMS.ApplicationCore.Models;

namespace Veam.EMS.ApplicationCore.Interfaces.Repositories
{
    public interface IAttendanceRepository
    {
        Task<List<AttendanceModel>> GetActiveAsync(AttendanceFilter filter);
        Task<List<AttendanceModel>> GetAbsentAsync(AttendanceFilter filter);
        Task<List<AttendanceModel>> GetHistoryAsync(AttendanceFilter filter);
    }
}
