using System;
using Veam.Domain.Core.ValueObjects;

namespace Veam.EMS.Domain
{
    public partial class EmployeeDocuments : BaseEntity
    {
        public CustomFile Empdoc { get; protected set; } 
        public long EmployeeId { get; protected set; }
        public Employee Employee { get; }

        //ctor
        protected EmployeeDocuments() { }

        public EmployeeDocuments(long FileId, long employeeId, string user,
            string name, string tagname,string fileUrl, string fileSize, bool isLocked)
        { 
            Empdoc = new CustomFile(name, tagname, fileUrl, fileSize,isLocked); 
            EmployeeId = employeeId;
            if (FileId != 0)
            {
                this.Id = FileId;
                UpdateAuditInfo(user);
            }
            else
            {
                CreateAuditInfo(user);
            }
        }
    }
     
}