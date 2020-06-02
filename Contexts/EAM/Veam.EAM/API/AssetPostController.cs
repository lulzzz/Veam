using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Veam.EAM.Application;
using Veam.EAM.ViewModels;

namespace Veam.EAM 
{
    //Post methods Are here
    public partial class AssetController : BaseController
    {

        // POST: Asset/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AssetSaveVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<AddNewAssetCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(SVM);
            }
        }

        // POST: Asset/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddToCenter(AddToCenterVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                //var command = Mapper.Map<AddNewAssetToCenterCommand>(SVM);
                //await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(SVM);
            }
        }

        // POST: Asset/UpdateWarranty/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateWarranty(long id, AssetWarrantyVM SVM)
        {
            if (id != SVM.assetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<UpdateAssetWarrantyInfoCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction("Index", "Asset");
            }
            return View(SVM);
        }



        // POST: Asset/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AssetSaveVM SVM)
        {
            if (id != SVM.assetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<UpdateAssetCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(SVM);
        }


        //POST: Asset/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, AssetQueryVM QVM)
        {
            try
            {
                var command = new DeleteAssetCommand { AssetId = id };
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["StatusMessage"] = "Error. please contact your SysAdmin with this message: " + ex;
                return View(QVM);
            }
        }


        [HttpPost]
        public async Task<ActionResult> PrintQR(List<int?> id, AssetQueryVM QVM)
        {

            return View();
        }
    }

}
