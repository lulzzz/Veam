using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.Base.Application;
using Veam.Base.ViewModels;

namespace Veam.Base.CenterMapVMs
{
    public class ProductController : BaseController
    {

        private readonly IProductService _services;

        public ProductController(IProductService services)
        {
            _services = services;
        }

        // GET: Hall
        public    ActionResult Index()
        {
            var entity =   _services.GetList();
            //var entity =   _services.GetQueryable();
            //var QVM = entity.Select(ProductQueryVM.Projection).ToList();
            var QVM = Mapper.Map<IEnumerable<ProductQueryVM>>(entity);
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
            //var QVM = new ProductQueryVM
            //{
            //    productId = (int)entity.Id,
            //    productName = entity.productName,
            //    productType.t = entity.productType.TypeName.ToString(),


            //};
            var QVM = Mapper.Map<ProductQueryVM>(entity);
            if (QVM == null)
            {
                return NotFound();
            }
            return View(QVM);
        }

        // GET: Building/Create
        public async Task<ActionResult> Create()
        {
            ViewData["TypeId"] = new SelectList(await _services.GetTypeasync(), "Id", "TypeName");
            ViewData["CategoryId"] = new SelectList(await _services.GetCategoryasync(), "Id", "Category");
            return View();
        }

        //  POST: Building/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductSaveVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<AddProductCommand>(SVM);
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
            ViewData["TypeId"] = new SelectList(await _services.GetTypeasync(), "Id", "TypeName");
            ViewData["CategoryId"] = new SelectList(await _services.GetCategoryasync(), "Id", "Category");
            var entity = await _services.GetByIdAsync(id);
            var SVM = Mapper.Map<ProductSaveVM>(entity);

            if (SVM == null)
            {
                return NotFound();
            }
            return View(SVM);

        }

        // POST: Building/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, ProductSaveVM SVM)
        {
            if (id != SVM.productId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<UpdateProductCommand>(SVM);
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
            var QVM = Mapper.Map<ProductQueryVM>(entity);
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
        public async Task<ActionResult> Delete(long id, ProductQueryVM QVM)
        {
            try
            {
                var command = new DeleteProductCommand { productId = id };
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