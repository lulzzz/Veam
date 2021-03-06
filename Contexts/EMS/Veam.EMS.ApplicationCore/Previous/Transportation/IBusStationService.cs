﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EMS.ApplicationCore.Models;

namespace Veam.EMS.ApplicationCore.Interfaces.Services
{
    public interface IBusStationService
    {
        Task<BusStationModel> GetByIdAsync(int id);
        Task<List<BusStationModel>> GetAllAsync();
        Task<List<BusStationModel>> GetByNameAsync(string name);
        Task<List<BusStationModel>> GetByRouteIdAsync(int routeId);
        Task AddAsync(BusStationModel model);
        Task UpdateAsync(BusStationModel model);
        Task DeleteAsync(int id);
    }
}
