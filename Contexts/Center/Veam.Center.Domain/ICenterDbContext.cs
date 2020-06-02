using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Veam.Centers.Application
{
    public interface ICenterDbContext
    {
        DbSet<Domain.CenterType> CenterTypes { get; set; }
        DbSet<Domain.Subsidery> Subsideries { get; set; }
     
        DbSet<Domain.Center> Center { get; set; }
        DbSet<Domain.Hall> Hall { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

   
}
