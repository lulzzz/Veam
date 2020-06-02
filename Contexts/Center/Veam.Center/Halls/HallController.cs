using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.Centers.Application;
using Veam.Centers.Application.CenterMap;
using Veam.Centers.Domain;
using Veam.Centers.ViewModels;

namespace Veam.Centers.CenterMapVMs
{
    public class HallController : BaseController
    {

        private readonly IHallService _services;

        public HallController(IHallService services)
        {
            _services = services;
        }

        // GET: Hall
        public async Task<ActionResult> Index()
        {
            var entity =  await _services.GetList();
           //this is working too
            //var QVM = entity.Select(x=>new HallQueryVM { 
            //    HallId=x.Id,
            //hallName=x.hallName,
            //CenterName=x.center.centerName});
          var QVM = Mapper.Map<IEnumerable<HallQueryVM>>(entity);
            return View( QVM);
        }

        //// GET: Building/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var entity = await _services.GetByIdAsync(id);
            var QVM = Mapper.Map<HallQueryVM>(entity);
            if (QVM == null)
            {
                return NotFound();
            }
            return View(QVM);
        }

        // GET: Building/Create
        public ActionResult Create()
        {
            ViewData["CenterList"] = new SelectList(_services.GetCenterList(), "Id", "centerName");
            return View();
        }

      //  POST: Building/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HallSaveVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<AddHallCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Details), "Center", new { Id = SVM.CenterId });
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
            ViewData["CenterList"] = new SelectList(_services.GetCenterList(), "Id", "centerName");
            var entity = await _services.GetByIdAsync(id);
            var SVM = Mapper.Map<HallSaveVM>(entity);
         
            if (SVM == null)
            {
                return NotFound();
            }
            return View(SVM);

        }

        // POST: Building/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, HallSaveVM SVM)
        {
            if (id != SVM.HallId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<UpdateHallCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Details), "Center", new { Id=SVM.CenterId});
                // return RedirectToAction(nameof(Index));
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
            var QVM = Mapper.Map<HallQueryVM>(entity);
            // var QVM = await readService.GetCenterById(id);
            if (QVM == null)
            {
                return NotFound();
            }

            return View(QVM);
        }

        // POST: Building/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long id, HallQueryVM QVM)
        {
            try
            {
                var entity = await _services.GetByIdAsync(id);
                var command = new DeleteHallCommand { hallId = id };
                await Mediator.Send(command);
                return RedirectToAction(nameof(Details), "Center", new { Id = entity.centerId });
                //return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["StatusMessage"] = "Error. please contact your SysAdmin with this message: " + ex;
                return View(QVM);
            }
        }

        //public static T ToModel<T>(this Hall entity)
        //{
        //    Type typeParameterType = typeof(T);

        //    if (typeParameterType == typeof(HallQueryVM))
        //    {
        //        Mapper.CreateMap<Hall, HallQueryVM>();
        //        return Mapper.Map<T>(entity);
        //    }

        //    return default(T);
        //}
    }


}