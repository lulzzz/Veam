using System.Collections.Generic;

namespace Veam.EMS.Domain
{
 /// <summary>
 /// Address,Contacts,Govt issued Ids,Images, and relevent Documents collections
 /// </summary>
    public class EmployeeBasicInfo
    {
        public EmployeeBasicInfo()
        {
            EmployeeAddress = new HashSet<EmployeeAddress>();
            EmployeeContacts = new HashSet<EmployeeContact>();
            govtIds = new HashSet<EmployeeGovtIds>();
            EmployeeImage = new HashSet<EmployeeImage>();
            EmployeeDocuments = new HashSet<EmployeeDocuments>();
        }
        public ICollection<EmployeeAddress> EmployeeAddress { get; set; }
        public ICollection<EmployeeContact> EmployeeContacts { get; set; }
        public ICollection<EmployeeGovtIds> govtIds { get; set; }
        public ICollection<EmployeeImage> EmployeeImage { get; set; }
        public ICollection<EmployeeDocuments> EmployeeDocuments { get; set; }
      
    }
}
