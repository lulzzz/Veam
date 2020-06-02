namespace Veam.Core.Domain
{
    public class Employee
    {
        public string Name { get; set; }
        public int DepartmentId { get; protected set; }
        public int groupid { get; protected set; }
        public int managerId { get; protected set; }
        //public Company company { get; set; }
        //public Group group { get; protected set; }
        //public Department departments { get; protected set; }
    }
}
