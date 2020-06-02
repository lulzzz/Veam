using System.Collections.Generic;

namespace Veam.Base.Domain
{

    public class ProductType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public List<ProductType> ProductTypeList()
        {
            List<ProductType> PT = new List<ProductType>()
                {
                       new ProductType{/*Id=1,*/TypeName=" Furniture"},
                       new ProductType{/*Id=2,*/TypeName=" FixedStructures"},
                       new ProductType{/*Id=3,*/TypeName=" HVAC"},
                       new ProductType{/*Id=4,*/TypeName=" Electrical"},
                       new ProductType{/*Id=5,*/TypeName=" Tools_Spare"},
                       new ProductType{/*Id=6,*/TypeName=" Electronic"},
                       new ProductType{/*Id=7,*/TypeName=" AudioVedio"},
                       new ProductType{/*Id=8,*/TypeName=" Software"},
                       new ProductType{/*Id=9,*/TypeName=" Food"},
                       new ProductType{/*Id=10,*/TypeName=" FMCG"},
                       new ProductType{/*Id=11,*/TypeName=" Decor"},
                       new ProductType{/*Id=12,*/TypeName=" Wellfare"},
                };
            return PT;
        }
    }

  
}