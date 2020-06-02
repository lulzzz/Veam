using System.Collections.Generic;

namespace Veam.Base.Domain
{

    public   class ProductCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }

        public List<ProductCategory> ProductCategoryList()
        {
            List<ProductCategory> PC = new List<ProductCategory>()
            {
                    new ProductCategory{/*Id=1, */Category="Asset"},
                    new ProductCategory{/*Id=2, */Category="SpareParts"},
                    new ProductCategory{/*Id=3, */Category="Component"},
                    new ProductCategory{/*Id=4, */Category="Accessory"},
                    new ProductCategory{/*Id=5, */Category="Consumable"},
                    new ProductCategory{/*Id=6, */Category="Capital"},
                    new ProductCategory{/*Id=7, */Category="Services"},
                    new ProductCategory{/*Id=8, */Category="Service Contracts"},
                    new ProductCategory{/*Id=9, */Category="New Project"},
                    new ProductCategory{/*Id=10,*/Category="Software"},
                    new ProductCategory{/*Id=11,*/Category="Maintenance"},
                    new ProductCategory{/*Id=12,*/Category="IT"},
            };
            return PC;
        }
    }
}