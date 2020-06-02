using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.CenterRent.Domain;

namespace Veam.CenterRent.Application
{
    public interface IBuildingServices
    {
        Task<IEnumerable<Building>> GetAllAsync();
        Task<Building> GetByIdAsync(long? id);
        Task<Building> GetEditAsync(long? id);
    }
}
