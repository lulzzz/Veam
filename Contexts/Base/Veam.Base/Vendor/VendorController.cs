using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.Base.Application;
using Veam.Base.ViewModels;

namespace Veam.Centers.CenterMapVMs
{
    public class VendorController : BaseController
    {

        private readonly IVendorService _services;

        public VendorController(IVendorService services)
        {
            _services = services;
        }

        // GET: Vendor
        public async Task<ActionResult> Index()
        {
            var entity = await _services.GetListAsync();
            var QVM = Mapper.Map<IEnumerable<VendorQueryVM>>(entity);
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
            var QVM = Mapper.Map<VendorQueryVM>(entity);
            if (QVM == null)
            {
                return NotFound();
            }
            return View(QVM);
        }

        // GET: Building/Create
        public ActionResult Create()
        {
            return View();
        }

      //  POST: Building/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VendorSaveVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<AddVendorCommand>(SVM);
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
            var SVM = Mapper.Map<VendorSaveVM>(entity);
         
            if (SVM == null)
            {
                return NotFound();
            }
            return View(SVM);

        }

        // POST: Building/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, VendorSaveVM SVM)
        {
            if (id != SVM.vendorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<UpdateVendorCommand>(SVM);
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
            var QVM = Mapper.Map<VendorQueryVM>(entity);
          
            if (QVM == null)
            {
                return NotFound();
            }

            return View(QVM);
        }

        // POST: Building/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long id, VendorQueryVM QVM)
        {
            try
            {
                var command = new DeleteVendorCommand { vendorId = id };
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