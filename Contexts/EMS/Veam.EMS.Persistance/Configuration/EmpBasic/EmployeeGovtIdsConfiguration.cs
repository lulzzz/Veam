using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veam.EMS.Domain;

namespace Veam.EMS.Data
{

    public class EmployeeGovtIdsConfiguration : IEntityTypeConfiguration<EmployeeGovtIds>
    {
        public void Configure(EntityTypeBuilder<EmployeeGovtIds> entity)
        {

        }

    }
    public class IdTypesConfiguration : IEntityTypeConfiguration<IdTypes>
    {
        public void Configure(EntityTypeBuilder<IdTypes> entity)
        {
            entity.HasData(
                new IdTypes() { Id = 1, IdType= "Adhaar" },
                new IdTypes() { Id = 2, IdType = "PAN" },
                new IdTypes() { Id = 3, IdType = "VoterId" },
                new IdTypes() { Id = 4, IdType = "PassPort" });
        }

    }
}