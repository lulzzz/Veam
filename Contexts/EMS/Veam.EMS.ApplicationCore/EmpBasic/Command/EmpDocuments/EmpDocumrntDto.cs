using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Veam.EMS.Application.EmpBasic.Command.EmpDocuments
{
    public class EmpDocumrntDto
    {
        public IFormFile file { get; set; }

        public bool IsLocked { get; set; }
        public string Tagname { get; set; }
        public string FileUrl { get; set; } 
        public long EmployeeId { get; set; } 
    }
    public class EmpDocumentsUploaded
    {
        public long Id { get; set; }
    }

   
}
