using System;
using System.Linq.Expressions;
using Veam.EMS.Domain;

namespace Veam.EMS.ApplicationCore.Specifications
{
    public class AuthoritySpecification : BaseSpecification<MasterAccountAuthority>
    {
        public AuthoritySpecification(Expression<Func<MasterAccountAuthority, bool>> filter)
            : base(filter)
        {
            AddInclude(x => x.Account);
            AddInclude(x => x.Authority);
        }
    }
}
