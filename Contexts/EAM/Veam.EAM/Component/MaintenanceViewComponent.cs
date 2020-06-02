using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Veam.EAM.Application;
using Veam.EAM.ViewModels;

namespace Veam.EAM.Component
{
    public class MaintenanceViewComponent : ViewComponent
    {
        private readonly IAssetServices _services;
        private readonly IMapper Mapper;

        public MaintenanceViewComponent(IAssetServices services, IMapper Mapper)
        {
            _services = services;
            this.Mapper = Mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(long? id)
        {
            var entity = await _services.GetByIdAsync(id);
            var QVM = Mapper.Map<AssetQueryVM>(entity);
            return View(QVM);
        }
    }

}
