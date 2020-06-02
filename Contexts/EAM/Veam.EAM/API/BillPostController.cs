using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.EAM.Application;
using Veam.EAM.ViewModels;

namespace Veam.EAM
{
    public partial class BillController : BaseController
    {
        // POST: AssetPurchase/Create
        // [ValidateAntiForgeryToken]
        [HttpPost] 
        public async Task<ActionResult> Create([FromBody] AssetPurchaseSaveVM SVM)
        {
            var assetid = SVM.assets.Select(x => x.assetId).Distinct();
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<AddAssetPurchaseCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(SVM);
            }
        }


        // POST: AssetPurchase/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AssetPurchaseSaveVM SVM)
        {
            if (id != SVM.assetpurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                SVM.user = GetCurrentUserName();
                //var command = Mapper.Map<updateAssetPurchaseCommand>(SVM);
                //await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(SVM);
        }

        // POST: AssetPurchase/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, AssetPurchaseQueryVM QVM)
        {
            try
            {
                //var command = new DeleteAssetCommand { AssetId = id };
                //await Mediator.Send(command);
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