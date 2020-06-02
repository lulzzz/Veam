using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Veam.EAM.Application;
using Veam.EAM.ViewModels;
using Veam.Infra.QRCoder;

namespace Veam.EAM.Component
{
    public class AssetQrViewComponent : ViewComponent
    {
        private readonly IAssetServices _services;
        private readonly IMapper Mapper;
        private readonly IQrCode _qrCode;

      
        public AssetQrViewComponent(IAssetServices services, IMapper Mapper, IQrCode qrCode)
        {
            _services = services;
            this.Mapper = Mapper;
            _qrCode = qrCode;
        }

        public async Task<IViewComponentResult> InvokeAsync(long? id)
        {
            var entity = await _services.GetByIdAsync(id);
            var QVM = Mapper.Map<AssetQr>(entity);
            var by = _qrCode.QrCodebuilder(QVM.assetId.ToString(), QVM.assetTag, QVM.serialNo);
            QVM.qrcode = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(by));
            return View(QVM);
        }
    }
}
