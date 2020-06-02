using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using Veam.Centers.Application;
using Veam.Centers.Application.CenterMap;
using Veam.Centers.Center;
using Veam.Centers.ViewModels;

namespace Veam.Centers.CenterMapVMs
{
    public class CenterController : BaseController
    {
        private readonly ICenterService _services;
        private readonly ICenterReadService readService;
        public CenterController(ICenterService services, ICenterReadService readService)
        {
            _services = services;
            this.readService = readService;
        }
        // GET: Building
        public async Task<ActionResult> Index()
        {
            //var entity = await _services.GetAllAsync();
            //var QVM = Mapper.Map<IEnumerable<CenterQueryVm>>(entity);

            // Through Dapper
            var QVM = await readService.GetAllAsync();
            return View(QVM);
        }

        // GET: Building/Details/5
        public async Task<ActionResult> Details(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var QVM = await readService.GetCenterById(id);
            //var entity = await _services.GetByIdAsync(id);
            //var QVM = Mapper.Map<CenterQueryVm>(entity);
            if (QVM == null)
            {
                return NotFound();
            }
            return View(QVM);
        }

        // GET: Building/Create
        public ActionResult Create()
        {
            ViewData["BuildingList"] = new SelectList(readService.GetBuilding(), "Id", "BuildingName");
            ViewData["Typelist"] = new SelectList(_services.GetCenterTypes(), "Id", "Type");
            ViewData["Subsiderylist"] = new SelectList(_services.GetSubsideries(), "Id", "company");
            return View();
        }

        // POST: Building/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CenterSaveVm SVM)
        {

            try
            {
                SVM.user = GetCurrentUserName();

                var command = Mapper.Map<AddCenterCommand>(SVM);
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
            var SVM = Mapper.Map<CenterSaveVm>(entity);
            ViewData["BuildingList"] = new SelectList(readService.GetBuilding(), "Id", "BuildingName");
            ViewData["Typelist"] = new SelectList(_services.GetCenterTypes(), "Id", "Type");
            if (SVM == null)
            {
                return NotFound();
            }
            return View(SVM);

        }

        // POST: Building/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, CenterSaveVm SVM)
        {
            if (id != SVM.CenterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<UpdateCenterCommand>(SVM);
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
            //var entity = await _services.GetByIdAsync(id);
            //var QVM = Mapper.Map<CenterQueryVm>(entity);
            var QVM = await readService.GetCenterById(id);
            if (QVM == null)
            {
                return NotFound();
            }

            return View(QVM);
        }

        // POST: Building/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long id, CenterQueryVm QVM)
        {
            try
            {
                var command = new DeleteCenterCommand { centerId = id };
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