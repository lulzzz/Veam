using Microsoft.AspNetCore.Http;

namespace Veam.EMS.EmpBasic
{
    public class ImageVM
    {
        public long EmployeeId { get; set; }
        public IFormFile img { get; set; }

        public bool IsLocked { get; set; }
        public string Tagname { get; set; }
        public string ImageUrl { get; set; }

        public long Id { get; set; }
        public string user { get; set; }
    }
}
