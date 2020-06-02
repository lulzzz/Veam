using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Veam.EMS.EmpBasic
{
    public partial class EmployeeController : BaseController
    {
        public readonly IEmployeeService _service;
        public readonly IEmployeeReadService _readservice;
        public EmployeeController(IEmployeeService service, IEmployeeReadService readservice)
        {
            _service = service;
            _readservice = readservice;
        }

        // GET: /<controller>/ getall
        public async Task<IActionResult> Index()
        {
            var entity = await _service.GetAllEmpAsync();
           // var QVM = Mapper.Map<IEnumerable<AssetQueryVM>>(entity);
            return View(entity);
        }
        public async Task<IActionResult> GetEmployee(long EmployeeId)
        {
            var entity = await _service.GetEmployee(EmployeeId);
            // var QVM = Mapper.Map<IEnumerable<AssetQueryVM>>(entity);
            return View(entity);
            
        }
        public async Task<IActionResult> GetByICardNoEmployee(string ICardNo)
        {
            var entity = await _service.GetEmployeeByCardNo(ICardNo);
            // var QVM = Mapper.Map<IEnumerable<AssetQueryVM>>(entity);
            return View(entity);
        }

        public IActionResult Register()
        { 
            return View( );
        }

        public IActionResult SaveHireInfo()
        {
            return View();
        }
        public IActionResult Resign()
        {
            return View();
        }
        public IActionResult SaveGlobalIds()
        {
            return View();
        }

        public IActionResult SaveAddress()
        {
           

            return View( );
        }

        public IActionResult SaveContactDetails()
        { 
            return View( );
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
