using System;
using System.Linq.Expressions;
using Veam.EMS.Domain;

namespace Veam.EMS.ApplicationCore.Specifications
{
    public class CalendarSpecification : BaseSpecification<MasterShiftCalendar>
    {
        public CalendarSpecification(Expression<Func<MasterShiftCalendar, bool>> filter)
            : base(filter)
        {
            AddInclude(x => x.Shift);
        }
    }
}
