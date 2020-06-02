using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public interface IBaseDbContext
    {
        DbSet<ProductCategory> ProductCategory { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<ProductType> ProductType { get; set; }

        DbSet<Vendor> Vendor { get; set; }
        DbSet<VendorLine> VendorLine { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
