using Veam.Domain.Core.Entity;

namespace Veam.Base.Domain
{
    /// <summary>
    /// contact Person of Vendor
    /// </summary>
    public class VendorLine : EntityBase
    {

        public string jobTitle { get; protected set; }
        public string note { get; set; }
        public Person person { get; protected set; }
        public Communication personContact { get; protected set; }
        public long vendorId { get; protected set; }
        public Vendor vendor { get; protected set; }

        protected VendorLine() { }
     
        public VendorLine(string jobTitle, Person person, Communication personContact, int vendorId, string user)
        {
            this.jobTitle = jobTitle;
            this.person = person;
            this.personContact = personContact;
            this.vendorId = vendorId;
            CreateAuditInfo(user);
        }
        public void Update(long id, string jobTitle, Person person, Communication personContact, int vendorId, string user)
        {
            this.Id = id;
            this.jobTitle = jobTitle;
            this.person = person;
            this.personContact = personContact;
            this.vendorId = vendorId;
            CreateAuditInfo(user);
        }
    }
}
