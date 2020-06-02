using System;

namespace Veam.EMS.EmpBasic
{
    public class ResignInfoVM
    {
        public long EmployeeId { get; set; }
        public DateTime tDate { get; set; }
        public int tType { get; set; }
        public string tReason { get; set; }
        public Status status { get; set; }
       
        public enum Status
        {
            Working,
            Resigned
        }
        public string user { get; set; }
        public long ID { get; set; }
    }
}
