using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.CenterRent.Application;
using Veam.CenterRent.ViewModels;

namespace Veam.CenterRent.Controllers
{
    public class BuildingController : BaseController
    {
        private readonly IBuildingServices _services;
        public BuildingController(IBuildingServices services)
        {
            _services = services;
        }
        // GET: Building
        public async Task<ActionResult> Index()
        {
            var entity = await _services.GetAllAsync();
            var QVM = Mapper.Map<IEnumerable<BuildingQueryVM>>(entity);

            return View(QVM);
        }

        // GET: Building/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _services.GetByIdAsync(id);
            var QVM = Mapper.Map<BuildingQueryVM>(entity);
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

        // POST: Building/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BuildingSaveVM SVM)
        {

            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<AddBuildingCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch
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
            var entity = await _services.GetEditAsync(id);
            var SVM = Mapper.Map<BuildingSaveVM>(entity);
            if (SVM == null)
            {
                return NotFound();
            }
            return View(SVM);

        }

     
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, BuildingSaveVM SVM)
        {
            if (id != SVM.buildingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<UpdateBuildingCommand>(SVM);
                await Mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            return View(SVM);
        }

         /// to change delete
        // GET: Building/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _services.GetEditAsync(id);
            var QVM = Mapper.Map<BuildingSaveVM>(entity);
            if (QVM == null)
            {
                return NotFound();
            }

            return View(QVM);
        }

        // POST: Building/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long id, BuildingQueryVM QVM)
        {
            try
            {
                var command = new DeleteBuildingCommand { buildingId = id };
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