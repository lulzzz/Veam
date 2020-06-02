namespace Veam.Base.Application
{
    public class ProductCommandDto
    {
        public string productCode { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public string uom { get; set; }

    }
}
