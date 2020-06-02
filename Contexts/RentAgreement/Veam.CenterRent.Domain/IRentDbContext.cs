using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Veam.CenterRent.Domain;

namespace Veam.CenterRent.Application
{
    public interface IRentDbContext
    {
        //rent
        DbSet<Building> Building { get; set; }
        DbSet<Permises> Permises { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
