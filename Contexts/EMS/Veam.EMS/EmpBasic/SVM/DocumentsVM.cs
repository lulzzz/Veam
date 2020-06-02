using Microsoft.AspNetCore.Http;

namespace Veam.EMS.EmpBasic
{
    public class DocumentsVM
    {
        public long EmployeeId { get; set; }

        public IFormFile file { get; set; }

        public bool IsLocked { get; set; }
        public string Tagname { get; set; }
        public string FileUrl { get; set; }

        public long Id { get; set; }
        public string user { get; set; }

    }
}
