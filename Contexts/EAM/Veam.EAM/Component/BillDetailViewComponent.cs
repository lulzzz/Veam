using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Veam.EAM.Application;
using Veam.EAM.ViewModels;

namespace Veam.EAM.Component
{
    public class BillDetailViewComponent : ViewComponent
    {
        private readonly IAssetServices _services;
        private readonly IMapper Mapper;

        public BillDetailViewComponent(IAssetServices services, IMapper Mapper)
        {
            _services = services;
            this.Mapper = Mapper;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(long? id)
        {
            var entity = await _services.GetByIdAsync(id);
            var QVM = Mapper.Map<AssetQueryVM>(entity);
            //should return bill as downloadable too
            return View(QVM);
        }
    }

}
