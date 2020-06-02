using System;
using System.Linq.Expressions;
using Veam.EMS.Domain;

namespace Veam.EMS.ApplicationCore.Specifications
{
    public class SectionSpecification : BaseSpecification<MasterSection>
    {
        public SectionSpecification(Expression<Func<MasterSection, bool>> filter)
            : base(filter)
        {
            AddInclude(x => x.Department);
        }
    }
}
