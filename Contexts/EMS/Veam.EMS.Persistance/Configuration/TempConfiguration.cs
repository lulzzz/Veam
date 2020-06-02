using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class TempConfiguration : IEntityTypeConfiguration<EmployeeGovtIds>
    {
        public void Configure(EntityTypeBuilder<EmployeeGovtIds> entity)
        {

        }

    }
}