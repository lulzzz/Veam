using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.EAM.Application;
using Veam.EAM.ViewModels;

namespace Veam.EAM
{   //api are here
    [Produces("application/json")] 
    public partial class AssetController : BaseController
    {
        [Route("api/Asset")]
        [HttpPost]
        public async Task<IActionResult> GetAssetAsync(long id )
        {
            var entity = await _services.GetAllAsync();
            var data = Mapper.Map<IEnumerable<AssetQueryVM>>(entity);
            var js = new
            {
                rows = data,
                current = 1,
                rowCount = 10,
                total = data.Count(),
            };
            return Json(js);
        }
        [Route("api/Asset/GetbyId/{Id}")]
        public async Task<IActionResult> GetAssetByIdAsync(long? masterid)
        {
            var entity = await _services.GetByIdAsync(masterid);
            var data = Mapper.Map<IEnumerable<AssetQueryVM>>(entity);
            var js = new
            {
                rows = data,
                current = 1,
                rowCount = 10,
                total = data.Count(),
            };
            return Json(js);
        }

        [HttpPost]
        [Route("api/Asset/postasset")]
        public async Task<IActionResult> PostAsset([FromBody] AssetSaveVM SVM)
        {
            if (SVM.assetId==0)
            {
                try
                {
                    SVM.user = GetCurrentUserName();
                    var command = Mapper.Map<AddNewAssetCommand>(SVM);
                    await Mediator.Send(command);
                    return Json(new { success=true,message="New Asset Has been Inserted in Database",Id =SVM.assetId });
                }
                catch (Exception ex)
                {
                    
                    return View(SVM);
                }
            }
            else
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<UpdateAssetCommand>(SVM);
                await Mediator.Send(command);
                return Json(new { success = true, message = "Edit Operation Successfull", Id = SVM.assetId });
            }
        }

        [HttpPost]
        [Route("api/Asset/delete")]
        public async Task<IActionResult> DeleteAsset([FromRoute] long Id)
        {
            var command = new DeleteAssetCommand { AssetId = Id };
            await Mediator.Send(command);
            return Json(new { success = true, message = "Delete Operation Successfull" });
        }


    }
}
