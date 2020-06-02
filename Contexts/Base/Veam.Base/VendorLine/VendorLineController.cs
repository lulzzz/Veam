using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.Base.Application;
using Veam.Base.ViewModels;
using Veam.Suppliers.ViewModels;

namespace Veam.Centers.CenterMapVMs
{
    public class VendorLineController : BaseController
    {

        private readonly IVendorLineService _services;

        public VendorLineController(IVendorLineService services)
        {
            _services = services;
        }

        // GET: VendorLine
        public async Task<ActionResult> Index()
        {
            var entity = await _services.GetList();
            var QVM = Mapper.Map<IEnumerable<VendorLineQueryVM>>(entity);
            return View(QVM);
        }

        //// GET: Building/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
             
            var entity = await _services.GetByIdAsync(id);
            var QVM = Mapper.Map<VendorLineQueryVM>(entity);
            if (QVM == null)
            {
                return NotFound();
            }
            return View(QVM);
        }

        // GET: Building/Create
        public ActionResult Create(long masterid, long id)
        {
           

            var check = _services.GetById(id);
            //  var selected = _context.Vendor.SingleOrDefault(m => m.vendorId == masterid);
            //var selected = _services.GetBymasterId(masterid);
            //  ViewData["vendorId"] = new SelectList(_context.Vendor, "vendorId", "vendorId");
            if (check == null)
            {
                VendorLineSaveVM objline = new VendorLineSaveVM();
                //  objline.vendor = selected;
                objline.vendorId = masterid;
                return View(objline);
            }
            else
            {
                var SVM = Mapper.Map<VendorLineSaveVM>(check);
                return View(SVM);
            }


        }

      //  POST: Building/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VendorLineSaveVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<AddVendorLineCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(SVM);
            }
        }

        // GET: Building/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _services.GetByIdAsync(id);
            var SVM = Mapper.Map<VendorLineSaveVM>(entity);
         
            if (SVM == null)
            {
                return NotFound();
            }
            return View(SVM);

        }

        // POST: Building/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, VendorLineSaveVM SVM)
        {
            //if (id != SVM.vendorLineId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<UpdateVendorLineCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(SVM);
        }


        // GET: Building/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _services.GetByIdAsync(id);
            var QVM = Mapper.Map<VendorLineQueryVM>(entity);
          
            if (QVM == null)
            {
                return NotFound();
            }

            return View(QVM);
        }

        // POST: Building/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long id, VendorLineQueryVM QVM)
        {
            try
            {
                var command = new DeleteVendorLineCommand { vendorLineId = id };
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["StatusMessage"] = "Error. please contact your SysAdmin with this message: " + ex;
                return View(QVM);
            }
        }
    }


}