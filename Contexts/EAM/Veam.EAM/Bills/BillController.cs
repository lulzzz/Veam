using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.Application.Core;
using Veam.EAM.Application;
using Veam.EAM.ViewModels;

namespace Veam.EAM
{
    public partial class BillController : BaseController
    {

        private readonly IAssetPurchaseServices _services;
        private readonly IDropDownServices _ddservices;
        private readonly IEAmDropDownServices _EAMddservices;
        public BillController(IAssetPurchaseServices services, IDropDownServices ddservices, IEAmDropDownServices EAMddservices)
        {
            _services = services;
            _ddservices = ddservices;
            _EAMddservices = EAMddservices;
        }

        // GET: AssetPurchase
        public async Task<ActionResult> Index()
        {
            var entity = await _services.GetAllAsync();
            var QVM = Mapper.Map<IEnumerable<AssetPurchaseQueryVM>>(entity);
            return View(QVM);
        }

        // GET: AssetPurchase/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _services.GetByIdAsync(id);
            var QVM = Mapper.Map<AssetPurchaseQueryVM>(entity);
            if (QVM == null)
            {
                return NotFound();
            }
            return View(QVM);
        }

        // GET: AssetPurchase/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            //  var id = new AssetPurchaseSaveVM().centerId;
            var SVM = new AssetPurchaseSaveVM
            {
                VendorList = await _ddservices.GetVendor(),
                CenterList = await _ddservices.GetCenter(),
                AssetList = await _EAMddservices.GetAsset(),
                AssetCategoriesList = await _ddservices.GetProductCategoriess(),
            };

            return View(SVM);
        }



        // GET: AssetPurchase/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _services.GetByIdAsync(id);
            var SVM = Mapper.Map<AssetPurchaseSaveVM>(entity);

            if (SVM == null)
            {
                return NotFound();
            }
            return View(SVM);
        }



        // GET: AssetPurchase/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _services.GetByIdAsync(id);
            var QVM = Mapper.Map<AssetPurchaseQueryVM>(entity);
            // var QVM = await readService.GetCenterById(id);
            if (QVM == null)
            {
                return NotFound();
            }

            return View(QVM);
        }


    }
     
}