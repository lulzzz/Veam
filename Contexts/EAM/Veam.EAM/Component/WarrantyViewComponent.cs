using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Veam.EAM.Application;
using Veam.EAM.ViewModels;

namespace Veam.EAM.Component
{

    public class WarrantyViewComponent : ViewComponent
    {
        private readonly IAssetServices _services;
        private readonly IMapper Mapper;
       
        public WarrantyViewComponent(IAssetServices services, IMapper Mapper)
        {
            _services = services;
            this.Mapper = Mapper;
        }
         
        public IViewComponentResult Invoke (long? masterid)
        { 
            var entity =    _services.GetByIdAsync(masterid).Result;
            var SVM = Mapper.Map<AssetWarrantyVM>(entity);
             
            return View(SVM);
        }
    }


  
}
