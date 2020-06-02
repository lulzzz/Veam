//using netcore.Data;
//using NonFactors.Mvc.Lookup;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using Veam.EAM.Domain;

//namespace netcore.Lookups
//{
//    public class ManufacturerLookupVM
//    {
//        [LookupColumn(Hidden = true)]
//        public int Id { get; set; }

//        [LookupColumn]
//        [Display(Name = "Logo")]
//        public string logoImage { get; set; }

//        [LookupColumn]
//        [Display(Name = "Manufacturer")]
//        public string name { get; set; }


//    }

//    public class MnaufacturerLookUp: MvcLookup<ManufacturerLookupVM>
//    {
//        private ApplicationDbContext Context { get; }
//        public MnaufacturerLookUp(ApplicationDbContext _Context)
//        {
//            Context = _Context;
//            GetId = (model) => model.Id.ToString();
//        }
//        public override IQueryable<ManufacturerLookupVM> GetModels()
//        {
//            return Context.Set<Manufacturer>().Select(m=>
//            new ManufacturerLookupVM { 
//            Id=m.Id,
//            name=m.name,
//            logoImage=m.logoImage
            
//            });
//        }
//    }

//}
