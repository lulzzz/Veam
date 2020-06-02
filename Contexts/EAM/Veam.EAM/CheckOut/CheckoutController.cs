using Barebone.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Veam.Application.Core;
using Veam.EAM.ViewModels;

namespace Veam.EAM
{
    public partial class CheckoutController : BaseController
    {
        private readonly IDropDownServices _ddservices;

        public CheckoutController(IDropDownServices ddservices)
        {
            _ddservices = ddservices;
        }

        // GET: AssetPurchase
        public async Task<ActionResult> Index()
        {
            var SVM = new CheckoutVM
            {
                CenterList = await _ddservices.GetCenter()
            };
            return View(SVM);
        }
        [HttpGet]
        public async Task<ActionResult> checkout(long masterid)
        {
            var SVM = new CheckoutSaveVM
            {
                assetId = masterid,
                CenterList = await _ddservices.GetCenter()
            };
            return View(SVM);
        }

        public async Task<ActionResult> Bulkcheckout()
        {
            var SVM = new BulkCheckOutSaveVM
            {
                CenterList = await _ddservices.GetCenter()
            };
            return View(SVM);
        }

    }
    [Produces("application/json")]
    public partial class CheckoutController : BaseController
    {
        [HttpPost]
        [Route("api/Checkout/checkoutpostapi")]
        public async Task<IActionResult> checkoutpostapi([FromBody] CheckoutSaveVM SVM)
        {
            return Json(new { success = true, message = "Edit data success." });
            // return View(SVM);
        }

        [HttpPost]
        [Route("api/Checkout/Bulkcheckout")]
        public async Task<ActionResult> Bulkcheckout([FromBody] BulkCheckOutSaveVM SVM)
        {

            SVM.user = GetCurrentUserName();

            return Json(new { success = true, message = "Edit data success." });
          //  return View(SVM);
        }
    }
   
}
