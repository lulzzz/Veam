using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Veam.EMS.EmpBasic
{
    public partial class EducationController : BaseController
    {
        public readonly IEmployeeService _service;
        public EducationController(IEmployeeService service)
        {
            _service = service;
        }

        // GET: /<controller>/ getall
       
        public IActionResult CreateDe()
        {
            return View();
        }

        public IActionResult SaveHireInfo()
        {
            return View();
        }
        public IActionResult Terminate()
        {
            return View();
        }
        public IActionResult SaveGlobalIds()
        {
            return View();
        }

        public IActionResult SaveAddress()
        {


            return View();
        }

        public IActionResult SaveContactDetails()
        {
            return View();
        }


        public IActionResult UploadImage()
        {
            return View();
        }
        public IActionResult UploadDocuments()
        {
            return View();
        }
    }
}
