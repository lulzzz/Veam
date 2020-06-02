using System;
using System.Linq.Expressions;
using Veam.EMS.Domain;

namespace Veam.EMS.ApplicationCore.Specifications
{
    public class JobFunctionSpecification : BaseSpecification<MasterJobFunction>
    {
        public JobFunctionSpecification(Expression<Func<MasterJobFunction, bool>> filter)
            : base(filter)
        {
            AddInclude(x => x.Section);
            AddInclude(x => x.Section.Department);
        }
    }
}
