using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Veam.Application.Core
{
    public interface IDropDownServices
    {
        Task<IEnumerable<SelectListItem>> GetProductCategoriess();
        Task<IEnumerable<SelectListItem>> GetProducts();
        //Task<IEnumerable<SelectListItem>> GetAsset();
        Task<IEnumerable<SelectListItem>> GetVendor();
        Task<IEnumerable<SelectListItem>> GetCenter();
        Task<IEnumerable<SelectListItem>> GetHallsByCenterId(long? masterId);
    }

    public interface IEAmDropDownServices
    { 
        Task<IEnumerable<SelectListItem>> GetAsset();
       
    }

}
