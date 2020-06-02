using NonFactors.Mvc.Lookup;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Veam.Data;
using Veam.EAM.Application;
using Veam.EAM.Domain;

namespace Veam.Lookups
{
    public class AssetLookUpVM
    {
        [LookupColumn(Hidden = true)]
        public long Id { get; set; }
        [LookupColumn]
        [Display(Name = "Asset Name")]
        public string Name { get; set; }
        [LookupColumn]
        [Display(Name = "Asset Tag")]
        public string AssetTag { get; set; }

        [LookupColumn]
        [Display(Name = "SerialNo")]
        public string serialno { get; set; }

    }
    public class AssetlookUp : MvcLookup<AssetLookUpVM>
    {
        private EAMDbContext Context { get; }
        public AssetlookUp(EAMDbContext _Context)
        {
          
            Context = _Context;
            GetId = (model) => model.Id.ToString();
        }
        public override IQueryable<AssetLookUpVM> GetModels()
        {
            return Context.Asset.Select(m =>
            new AssetLookUpVM
            {
                Id = m.Id,
                Name = m.assetName,
                AssetTag = m.assetTag,
                serialno = m.serialNo,
            }).AsQueryable();
        }
    }
}
