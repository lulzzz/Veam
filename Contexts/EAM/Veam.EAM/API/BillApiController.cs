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
    //public partial class BillController : BaseController
    //{
    //    [Produces("application/json")]
    //    [Route("api/Asset")]
    //    public async Task<JsonResult> GetAssetAsync()
    //    {
    //        var entity = await _services.GetAllAsync();
    //        var data = Mapper.Map<IEnumerable<AssetPurchaseQueryVM>>(entity);
    //        var js = new
    //        {
    //            rows = data,
    //            current = 1,
    //            rowCount = 10,
    //            total = data.Count(),
    //        };
    //        return Json(js);
    //    }
    //    public async Task<JsonResult> GetAssetByIdAsync(long? masterid)
    //    {
    //        var entity = await _services.GetByIdAsync(masterid);
    //        var data = Mapper.Map<IEnumerable<AssetPurchaseQueryVM>>(entity);
    //        var js = new
    //        {
    //            rows = data,
    //            current = 1,
    //            rowCount = 10,
    //            total = data.Count(),
    //        };
    //        return Json(js);
    //    }

    //    public async Task<IActionResult> PostAsset([FromBody] AssetPurchaseSaveVM SVM)
    //    {
    //        if (SVM.assetpurchaseId == 0)
    //        {
    //            try
    //            {
    //                SVM.user = GetCurrentUserName();
    //                var command = Mapper.Map<AddAssetPurchaseCommand>(SVM);
    //                await Mediator.Send(command);
    //                return Json(new { success = true, message = "New Asset Has been Inserted in Database", Id = SVM.assetId });
    //            }
    //            catch (Exception ex)
    //            {

    //                return View(SVM);
    //            }
    //        }
    //        else
    //        {
    //            SVM.user = GetCurrentUserName();
    //            //var command = Mapper.Map<updateAssetPurchaseCommand>(SVM);
    //            //await Mediator.Send(command);
    //            return Json(new { success = true, message = "Edit Operation Successfull", Id = SVM.assetId });
    //        }
    //    }
    //    public async Task<IActionResult> DeleteAsset([FromRoute] long Id)
    //    {
    //        //var command = new DeleteAssetCommand { AssetId = Id };
    //        //await Mediator.Send(command);
    //        return Json(new { success = true, message = "Delete Operation Successfull" });
    //    }


    //}
}
