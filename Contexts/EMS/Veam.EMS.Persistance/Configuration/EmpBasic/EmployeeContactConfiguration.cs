using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{
    public class EmployeeContactConfiguration : IEntityTypeConfiguration<EmployeeContact>
    {
        public void Configure(EntityTypeBuilder<EmployeeContact> entity)
        {

        }

    }
}