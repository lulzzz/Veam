using System;
using System.Linq.Expressions;
using Veam.EMS.Domain;

namespace Veam.EMS.ApplicationCore.Specifications
{
    public class EmployeeSkillSpecification : BaseSpecification<EmployeSkills>
    {
        public EmployeeSkillSpecification(Expression<Func<EmployeSkills, bool>> filter) 
            : base(filter)
        {
            AddInclude(x => x.Skill);
            AddInclude(x => x.Skill.SkillGroup);
            AddInclude(x => x.Skill.SkillType);
        }
    }
}
