using System;
using Veam.Domain.Core.Entity;

namespace Veam.Base.Domain
{
    public class Product : EntityBase
    {
       
        public string productCode { get; protected set; }
        public string productName { get; protected set; }
        public string description { get; protected set; }
        public string uom { get; protected set; }
        //
        public int CategoryId { get; protected set; }
        public int TypeId { get; protected set; }
      //nav
        public ProductCategory productCategory { get; protected set; }
        public ProductType productType { get; protected set; }

        protected Product()
        {

        }
        public Product(string productCode, string productName, string description,
            int categoryId, int typeId, string uom, string user)
        {
            this.productCode = productCode ?? throw new ArgumentNullException(nameof(productCode));
            this.productName = productName ?? throw new ArgumentNullException(nameof(productName));
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            CategoryId = categoryId;
            TypeId = typeId;
            this.uom = uom ?? throw new ArgumentNullException(nameof(uom));
            CreateAuditInfo(user);
        }
        public void Update(long productid, string productCode, string productName, string description,
            int categoryId, int typeId, string uom, string user)
        {
            this.Id = productid;
            this.productCode = productCode ?? throw new ArgumentNullException(nameof(productCode));
            this.productName = productName ?? throw new ArgumentNullException(nameof(productName));
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            CategoryId = categoryId;
            TypeId = typeId;
            this.uom = uom ?? throw new ArgumentNullException(nameof(uom));
            UpdateAuditInfo(user);
        }

    }

}
