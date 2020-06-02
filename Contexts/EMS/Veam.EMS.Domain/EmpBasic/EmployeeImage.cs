using System;
using System.Collections.Generic;
using Veam.Domain.Core.ValueObjects;

namespace Veam.EMS.Domain
{
    public partial class EmployeeImage : BaseEntity
    {
        public CustomFile EmpImage { get; protected set; }

        public long EmployeeId { get; protected set; } 
        public Employee Employee { get;   }

        //ctor
        protected EmployeeImage() { }

        public EmployeeImage( long employeeId, long EmpImageId, string user,
          string name, string tagname, string fileUrl, string fileSize, bool isLocked)
        {
            EmpImage = new CustomFile(name, tagname, fileUrl, fileSize, isLocked);
            EmployeeId = employeeId;

            if (EmpImageId != 0)
            {
                this.Id = EmpImageId;
                UpdateAuditInfo(user);
            }
            else
            {
                CreateAuditInfo(user);
            }
        }
        
    }
}
