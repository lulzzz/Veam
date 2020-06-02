namespace Veam.EMS.Application.EmpBasic
{
    public class EmpAddressDto
    {
      
        public long EmployeeId { get; set; }

        public long addressId { get; set; }
        public string addresssType { get; set; }

        public string line1 { get;  set; }
        public string line2 { get;  set; }
        public string city { get;  set; }
        public string state { get;  set; }
        public string zip { get; set; }
    }

    public class EmpAddressCreated
    {
        public long Id { get; set; }
    }
    public class EmpAddressChanged
    {
        public long Id { get; set; }
    }
}
