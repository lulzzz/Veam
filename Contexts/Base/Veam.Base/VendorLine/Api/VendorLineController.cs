using Barebone.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.Base.Application;
using Veam.Base.ViewModels;

namespace Veam.Centers.API
{
    [Produces("application/json")]
    [Route("api/VendorLine")]
    public class VendorLineController : BaseController
    {
        private readonly IVendorLineService _services;

        public VendorLineController(IVendorLineService services)
        {
            _services = services;
        }

        // GET: api/VendorLine
        [HttpGet]
        //[Authorize]
        public IActionResult GetVendorLine(long? masterid)
        {
            var entity =   _services.GetListByMaserId(masterid);
         var data = Mapper.Map<IEnumerable<VendorLineQueryVM>>(entity);
            return Json(new { data });
        }

        // POST: api/VendorLine
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostVendorLine([FromBody] VendorLineSaveVM SVM)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (SVM.vendorLineId == 0)
            {
                try
                {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<AddVendorLineCommand>(SVM);
                await Mediator.Send(command);
                return Json(new { success = true, message = "Add new data success." });
                }
                catch (Exception ex)
                {
                    
                    return View(SVM);
                }
            }
            else
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<UpdateVendorLineCommand>(SVM);
                await Mediator.Send(command); 
                return Json(new { success = true, message = "Edit data success." });
            }

        }

        // DELETE: api/VendorLine/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteVendorLine([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var vendorLine = await _context.VendorLine.SingleOrDefaultAsync(m => m.vendorLineId == id);
            //if (vendorLine == null)
            //{
            //    return NotFound();
            //}

            var command = new DeleteVendorLineCommand { vendorLineId = id };
            await Mediator.Send(command);

            return Json(new { success = true, message = "Delete success." });
        }


        //private bool VendorLineExists(string id)
        //{
        //    return _context.VendorLine.Any(e => e.vendorLineId == id);
        //}


    }
     
}