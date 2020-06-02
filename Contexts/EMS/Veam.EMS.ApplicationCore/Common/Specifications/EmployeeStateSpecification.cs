using System;
using System.Linq.Expressions;
using Veam.EMS.Domain;

namespace Veam.EMS.ApplicationCore.Specifications
{
    public class EmployeeStateSpecification : BaseSpecification<EmployeeState>
    {
        public EmployeeStateSpecification(Expression<Func<EmployeeState, bool>> filter)
            : base(filter)
        {
            AddInclude(x => x.JobFunction);
            AddInclude(x => x.JobFunction.Section);
            AddInclude(x => x.JobFunction.Section.Department);
            AddInclude(x => x.Shift);
        }
    }
}
