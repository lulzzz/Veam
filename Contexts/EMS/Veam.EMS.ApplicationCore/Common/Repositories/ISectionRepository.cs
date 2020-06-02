using System.Collections.Generic;
using Veam.EMS.Domain;

namespace Veam.EMS.ApplicationCore.Interfaces.Repositories
{
    public interface ISectionRepository : IRepository<MasterSection>, IAsyncRepository<MasterSection>
    {
        IEnumerable<MasterSection> GetAllWithDepartment();
        IEnumerable<MasterSection> GetByNameWithDepartment(string name);
    }
}
