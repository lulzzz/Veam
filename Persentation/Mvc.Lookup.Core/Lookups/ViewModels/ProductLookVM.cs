//using netcore.Data;
//using netcore.Models.Invent;
//using NonFactors.Mvc.Lookup;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;

//namespace netcore.Lookups
//{
//    public class ProductLookVM
//    {

//        [LookupColumn(Hidden = true)]
//        [Display(Name = "Product Id")]
//        public string productId { get; set; }

//        [LookupColumn]
//        [Display(Name = "Product Code")]
//        public string productCode { get; set; }

//        [LookupColumn]
//        [Display(Name = "Product Name")]
//        public string productName { get; set; }
//    }
//    public class ProductLookUp : MvcLookup<ProductLookVM>
//    {
//        private ApplicationDbContext Context { get; }
//        public ProductLookUp(ApplicationDbContext _Context)
//        {
//            Context = _Context;
//            GetId = (model) => model.productId;
//        }
//        public override IQueryable<ProductLookVM> GetModels()
//        {


//            return Context.Set<Product>().Select(p =>
//            new ProductLookVM
//            {
//                productId = p.productId,
//                productCode = p.productCode,
//                productName = p.productName
//            }).AsQueryable();

//        }
//    }

//}
