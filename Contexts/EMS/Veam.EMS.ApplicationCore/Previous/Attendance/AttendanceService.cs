using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Helper;
using Veam.EMS.ApplicationCore.Interfaces.Repositories;
using Veam.EMS.ApplicationCore.Interfaces.Services;
using Veam.EMS.ApplicationCore.Models;

namespace Veam.EMS.ApplicationCore.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attenRepository;

        public AttendanceService(IAttendanceRepository attenRepository)
        {
            _attenRepository = attenRepository;
        }

        public async Task<List<AttendanceModel>> GetHistoryAsync(AttendanceFilter filter)
        {
            return await _attenRepository.GetHistoryAsync(filter);
        }

        public async Task<List<AttendanceModel>> GetActiveAsync(AttendanceFilter filter)
        {
            return await _attenRepository.GetActiveAsync(filter);
        }

        public async Task<List<AttendanceModel>> GetAbsentAsync(AttendanceFilter filter)
        {
            return await _attenRepository.GetAbsentAsync(filter);
        }
    }
}
