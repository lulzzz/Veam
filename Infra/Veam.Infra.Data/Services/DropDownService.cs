using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.Application.Core;
//using Veam.Barebone.Services;
using Veam.Data;

namespace Veam.Infra.Data
{

    public class DropDownService : IDropDownServices
    {
        private readonly DataDbContext _repo;

        public DropDownService(DataDbContext repo)
        {
            _repo = repo;
        }

      

        public async Task<IEnumerable<SelectListItem>> GetCenter()
        {
            var List = await _repo.Center.ToListAsync();
            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var data in List)
            {
                item.Add(new SelectListItem()
                {
                    Value = data.Id.ToString(), 
                    Text = data.centerName ,
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetHallsByCenterId(long? masterId)
        {
            var List = await _repo.Hall.Where(h=>h.centerId.Equals(masterId)).ToListAsync();
            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var data in List)
            {
                item.Add(new SelectListItem()
                {
                    Value = data.Id.ToString(),
                    Text = data.hallName,
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetProductCategoriess()
        {
            var List = await _repo.ProductCategory.ToListAsync();
            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var data in List)
            {
                item.Add(new SelectListItem()
                {
                    Value = data.Id.ToString(),
                    Text = data.Category,
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetProducts()
        {
            var Products = await _repo.Product.ToListAsync();
            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var data in Products)
            {
                item.Add(new SelectListItem()
                {
                  Value   =// data.Id.ToString(),
                    data.productName,
                    Text = data.productName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetVendor()
        {
            var vendorList = await _repo.Vendor.ToListAsync();
            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var data in vendorList)
            {
                item.Add(new SelectListItem()
                {
                    Value = data.Id.ToString(),
                   // data.Company.RegisterCompanyName,
                    Text = data.Company.RegisterCompanyName,
                });
            }

            return item;
        }
    }
}
//public async Task<IEnumerable<SelectListItem>> GetAsset()
//{
//    var List = await _repo.Asset.ToListAsync();
//    var item = new List<SelectListItem>
//    {
//        new SelectListItem() { Value = null, Text ="",Selected = true }
//    };

//    foreach (var data in List)
//    {
//        item.Add(new SelectListItem()
//        {
//            Value = data.Id.ToString(),
//            Text = data.assetName,
//        });
//    }

//    return item;
//}