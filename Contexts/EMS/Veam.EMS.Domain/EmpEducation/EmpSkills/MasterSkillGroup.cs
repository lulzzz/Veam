using System;
using System.Collections.Generic;

namespace Veam.EMS.Domain
{
    public partial class MasterSkillGroup : BaseEntity
    {
        public MasterSkillGroup()
        {
            MasterSkill = new HashSet<MasterSkill>();
        }

        public int SkillGroupId { get; set; }
        public string SkillGroupName { get; set; }

        public ICollection<MasterSkill> MasterSkill { get; set; }
    }
}
