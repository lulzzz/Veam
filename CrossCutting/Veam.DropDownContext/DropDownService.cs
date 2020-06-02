//using Microsoft.AspNetCore.Mvc.Rendering;
//using Sequel;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Veam.Application.Core;
//using Veam.EAM.ViewModels;

//namespace Veam.DropDownContext
//{

//    public class DropDownService : IDropDownServices
//    {
//        private readonly IBaseReadModelRepository _repo;
//        public DropDownService(IBaseReadModelRepository repo)
//        {
//            _repo = repo;
//        }
//        public async Task<IEnumerable<SelectListItem>> GetProducts()
//        {
//            var sqlBuilder = new SqlBuilder()
//               .Select("P.Id as Id ,P.productName As productName")
//               .From("dbo.Product P");
//            string sql = sqlBuilder.ToSql();
//            var Products = await _repo.GetAllAsync< ProductLookupVM>(sql);

//            var item = new List<SelectListItem>
//            {
//                new SelectListItem() { Value = null, Text ="",Selected = true }
//            };

//            foreach (var data in Products)
//            {
//                item.Add(new SelectListItem()
//                {
//                    Value = data.Id.ToString(),
//                    Text = data.productName
//                });
//            }

//            return item;
//        }
//    }
//}
