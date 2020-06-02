using Microsoft.EntityFrameworkCore;
using Veam.CenterRent.Application;
using Veam.CenterRent.Domain;

namespace Veam.CenterRent.Data
{
    public class RentDbContext : DbContext, IRentDbContext
    {
        public RentDbContext(DbContextOptions<RentDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            //base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(RentDbContext).Assembly);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Building> Building { get; set; }
        public DbSet<Permises> Permises { get; set; }

    }
}