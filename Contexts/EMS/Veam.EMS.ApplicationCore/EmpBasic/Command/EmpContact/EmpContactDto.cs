namespace Veam.EMS.Application.EmpBasic
{
    public class EmpContactDto
    {

        public long EmployeeId { get; set; }
        public long contactId { get; set; }
        public string mobilePhone { get;   set; }
        public string officePhone { get;   set; }
        public string personalEmail { get;   set; }
        public string workEmail { get;   set; }
    }
    public class EmpContactCreated
    {
        public long Id { get; set; }
    }
    public class EmpContactChanged
    {
        public long Id { get; set; }
    }
}
