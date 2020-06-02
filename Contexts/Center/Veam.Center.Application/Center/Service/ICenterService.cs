using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Veam.Centers.Application
{
    public interface ICenterService
    {
        Task<Domain.Center> GetByIdAsync(long? id);
        IEnumerable<Domain.CenterType> GetCenterTypes();
        IEnumerable<Domain.Subsidery> GetSubsideries();
    }
}