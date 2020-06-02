using System;

namespace Veam.EMS.Domain
{
    public class EmployeeGovtIds: BaseEntity
    { 
        public IdTypes IdType { get; protected set; }
        public string IdNos { get; protected set; }

        public long EmployeeId { get; protected set; }
        public Employee Employee { get;  }

        //ctor and rules
        protected EmployeeGovtIds() { } 

        public EmployeeGovtIds(string idType, string idNos, long employeeId, 
            long EmpGlobalId, string user)
        {
            IdType = new IdTypes(idType);  
            IdNos = idNos ?? throw new ArgumentNullException(nameof(idNos));
            EmployeeId = employeeId ;
            if (EmpGlobalId != 0)
            {
                this.Id = EmpGlobalId;
                UpdateAuditInfo(user);
            }
            else
            {
                CreateAuditInfo(user);
            }
        }
    }

    /// <summary>
    /// Pan, Adhaar, VoterIds, passport
    /// </summary>
    public class IdTypes
    {
        public int Id { get; set; }
        public string IdType { get; set; }

        public IdTypes( string idtype)
        {
            this.IdType = idtype;
        }
    }
}
