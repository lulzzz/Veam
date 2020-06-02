using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Veam.Application.Core;
using Veam.Data;

namespace Veam.EAM.Data
{
    public class EAMDropDownServices : IEAmDropDownServices
    {
        private readonly EAMDbContext _repo;
        public EAMDropDownServices(EAMDbContext repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<SelectListItem>> GetAsset()
        {
            var List = await _repo.Asset.ToListAsync();
            var item = new List<SelectListItem>
                {
                    new SelectListItem() { Value = null, Text ="",Selected = true }
                };

            foreach (var data in List)
            {
                item.Add(new SelectListItem()
                {
                    Value = data.Id.ToString(),
                    Text = data.assetName,
                });
            }

            return item;
        }
    }
}