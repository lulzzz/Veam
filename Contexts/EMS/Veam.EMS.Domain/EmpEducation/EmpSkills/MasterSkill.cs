﻿using System;
using System.Collections.Generic;

namespace Veam.EMS.Domain
{
    public partial class MasterSkill : BaseEntity
    {
        public MasterSkill()
        {
            EmployeSkills = new HashSet<EmployeSkills>();
        }

        public int SkillId { get; set; }
        public int SkillGroupId { get; set; }
        public int SkillTypeId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }

        public MasterSkillGroup SkillGroup { get; set; }
        public MasterSkillType SkillType { get; set; }
        public ICollection<EmployeeSkills> EmployeSkills { get; set; }
    }
}
