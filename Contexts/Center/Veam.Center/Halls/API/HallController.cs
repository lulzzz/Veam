//using Barebone.Controllers;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using Veam.Centers.Application;
//using Veam.Centers.Application.CenterMap;
//using Veam.Centers.ViewModels;

//namespace Veam.Centers.API
//{
//    [Produces("application/json")]
//    [Route("api/Hall")]
//    public class HallController : BaseController
//    {
//        private readonly IHallService _services;

//        public HallController(IHallService services)
//        {
//            _services = services;
//        }

//        //GET: api/VendorLine
//        [HttpGet]
//        [Authorize]
//        public IActionResult GetHall(long? masterid)
//        {
//            return Json(new { data = _services.GetListByMaserId(masterid) });
//        }

//        // POST: api/VendorLine
//        [HttpPost]
//        [Authorize]
//        public async Task<IActionResult> PostVendorLine([FromBody] HallSaveVM SVM)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            var command = Mapper.Map<AddHallCommand>(SVM);
//            await Mediator.Send(command);
//            return Json(new { success = true, message = "Add new data success." });
//            //if (vendorLine.vendorLineId == string.Empty)
//            //{
//            //    vendorLine.vendorLineId = Guid.NewGuid().ToString();
//            //    _context.VendorLine.Add(vendorLine);
//            //    await _context.SaveChangesAsync();
//            //    return Json(new { success = true, message = "Add new data success." });
//            //}
//            //else
//            //{
//            //    _context.Update(vendorLine);
//            //    await _context.SaveChangesAsync();
//            //    return Json(new { success = true, message = "Edit data success." });
//            //}

//        }

//        //// DELETE: api/VendorLine/5
//        //[HttpDelete("{id}")]
//        //[Authorize]
//        //public async Task<IActionResult> DeleteVendorLine([FromRoute] string id)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }

//        //    var vendorLine = await _context.VendorLine.SingleOrDefaultAsync(m => m.vendorLineId == id);
//        //    if (vendorLine == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    _context.VendorLine.Remove(vendorLine);
//        //    await _context.SaveChangesAsync();

//        //    return Json(new { success = true, message = "Delete success." });
//        //}


//        //private bool VendorLineExists(string id)
//        //{
//        //    return _context.VendorLine.Any(e => e.vendorLineId == id);
//        //}


//    }

//}
