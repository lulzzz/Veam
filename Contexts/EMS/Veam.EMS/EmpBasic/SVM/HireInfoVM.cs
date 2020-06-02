using System;

namespace Veam.EMS.EmpBasic
{
    public class HireInfoVM
    {
       
        public long EmployeeId { get; set; }
        public string CardId { get; set; }
        public HireType hireType { get; set; }
        public DateTime HireDate { get; set; }
        public int HireforSubsidery { get; set; }//form readtable
        public EmployeeType employeeType { get; set; }

        public enum HireType
        {
            Direct,
            Indirect,
        }
        public enum EmployeeType
        {
            Contractual,
            OnCompanyRoll
        }
        //common
        public int ID { get; set; }
        public string user { get; set; }
    }
}
