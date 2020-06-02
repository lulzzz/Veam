﻿using System;
using System.Collections.Generic;

namespace Veam.EMS.Domain
{
    public partial class MasterJobPosition : BaseEntity
    {
        public MasterJobPosition()
        {
            EmployeeState = new HashSet<EmployeeState>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public string PositionCode { get; set; }

        public ICollection<EmployeeState> EmployeeState { get; set; }
    }
}
