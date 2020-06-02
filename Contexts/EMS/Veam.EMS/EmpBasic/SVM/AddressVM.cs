namespace Veam.EMS.EmpBasic
{
    public class AddressVM
    {
        public long EmployeeId { get; set; } 
        public AddressType addresssType { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }

        public enum AddressType
        {
            CurrrentAddress = 1,
            PermanentAddress = 2,
        }

        public long ID { get; set; }
        public string user { get; set; }
        
    }
}
