using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.EAM.Application;
using Veam.EAM.ViewModels;
using Veam.Infra.QRCoder;

namespace Veam.EAM.Component
{
    public class PrintQrsViewComponent : ViewComponent
    {
        private readonly IAssetServices _services;
        private readonly IMapper Mapper;
        private readonly IQrCode _qrCode;


        public PrintQrsViewComponent(IAssetServices services, IMapper Mapper, IQrCode qrCode)
        {
            _services = services;
            this.Mapper = Mapper;
            _qrCode = qrCode;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<long> ids)
        {
            List<AssetQr> QrList = new List<AssetQr>();
            foreach(var id in ids) { 
            var entity = await _services.GetByIdAsync(id);
            var QVM = Mapper.Map<AssetQr>(entity);
            var by = _qrCode.QrCodebuilder(QVM.assetId.ToString(), QVM.assetTag, QVM.serialNo);
            QVM.qrcode = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(by));
                QrList.Add(QVM);
            }
            return View(QrList);
        }
    }
}
