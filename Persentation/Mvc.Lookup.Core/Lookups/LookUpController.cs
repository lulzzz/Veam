using Microsoft.AspNetCore.Mvc;
using NonFactors.Mvc.Lookup;
using Veam.CenterRent.Application;
using Veam.Data;
using Veam.Lookups;

namespace Barebone.Controllers
{
    [Produces("application/json")]
    public class LookupController : Controller
    {
        private readonly DataDbContext _context;

        public LookupController(DataDbContext context)
        {
            _context = context;
        }
      
        public JsonResult BuildingLookup(LookupFilter filter)
        {
            return Json(new BuidingLookUP(_context) { Filter = filter }.GetData());
        }
        public JsonResult CenterLookup(LookupFilter filter)
        {
            return Json(new CenterLookUp(_context) { Filter = filter }.GetData());
        }
        public JsonResult HallLookup(LookupFilter filter,long?centerId)
        {
            filter.AdditionalFilters[nameof(HallLookUpVM.centerId)] = centerId;
            return Json(new HallLookUp(_context) { Filter = filter }.GetData());
        }

        //public JsonResult AssetLookup(LookupFilter filter)
        //{
        //    return Json(new AssetlookUp(_context) { Filter = filter }.GetData());
        //}
    }
}


//[HttpGet]
//public JsonResult ManufacturerLookup(LookupFilter filter)
//{
//    return Json(new MnaufacturerLookUp(_context) { Filter = filter }.GetData());
//}
//[HttpGet]
//public JsonResult ProductLookup(LookupFilter filter)
//{
//    return Json(new ProductLookUp(_context) { Filter = filter }.GetData());
//}
//[HttpGet]
//public JsonResult modelLookup(LookupFilter filter)
//{
//    return Json(new AssetModelLookUp(_context) { Filter = filter }.GetData());
//}