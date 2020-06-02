using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.Application.Core;
using Veam.EAM.Application;
using Veam.EAM.ViewModels;
using Veam.Infra.QRCoder;

namespace Veam.EAM
{
    //get Methods are Here
    public partial class AssetController : BaseController
    {
        private readonly IAssetServices _services;
        private readonly IDropDownServices _ddservices;
        
        public AssetController(IAssetServices services, IDropDownServices ddservices )
        {
            _services = services;
            _ddservices = ddservices;
            //_qrCode = qrCode;
        }

        // GET: Asset
        public async Task<ActionResult> Index()
        {
            var entity = await _services.GetAllAsync();
            var QVM = Mapper.Map<IEnumerable<AssetQueryVM>>(entity);
            return View(QVM);

        }

        // GET: Asset/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _services.GetByIdAsync(id);
            var QVM = Mapper.Map<AssetQueryVM>(entity);
            //now called from view component
            //var by = _qrCode.QrCodebuilder(QVM.assetId.ToString(), QVM.assetTag, QVM.serialNo);
            //QVM.qrcode = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(by));
            if (QVM == null)
            {
                return NotFound();
            }
            return View(QVM);
        }

        // GET: Asset/Create
        public async Task<ActionResult> Create()
        {

            var SVM = new AssetSaveVM
            {
                Products = await _ddservices.GetProducts(),
            };
            return View(SVM);
        }

        public async Task<ActionResult> UpdateWarranty(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var entity = await _services.GetByIdAsync(id);
            var SVM = Mapper.Map<AssetWarrantyVM>(entity);

            if (SVM == null)
            {
                return NotFound();
            }
            return View(SVM);
        }

        // GET: Asset/Create
        public async Task<ActionResult> AddToCenter()
        {

            var SVM = new AddToCenterVM
            {
                Products = await _ddservices.GetProducts(),
                center = await _ddservices.GetCenter(),
                //Hall = await _ddservices.h(),
            };
            return View(SVM);
        }


     
        // GET: Asset/Edit/5
        public async Task<ActionResult> Edit(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var entity = await _services.GetByIdAsync(id);
            var SVM = Mapper.Map<AssetSaveVM>(entity);
            SVM.Products = await _ddservices.GetProducts();
            if (SVM == null)
            {
                return NotFound();
            }
            return View(SVM);
        }
          
        // GET: Asset/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _services.GetByIdAsync(id);
            var QVM = Mapper.Map<AssetQueryVM>(entity);
            // var QVM = await readService.GetCenterById(id);
            if (QVM == null)
            {
                return NotFound();
            }

            return View(QVM);
        }

        [HttpGet]
        public async Task<ActionResult> PrintQR()
        {


            return View();
        }
    }

   
  
}