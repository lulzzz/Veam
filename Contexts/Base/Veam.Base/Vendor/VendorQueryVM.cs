namespace Veam.Base.ViewModels
{
    public class VendorQueryVM
    {
        public long vendorId { get; set; }
        public string RegisterCompanyName { get; set; }
        public string Country { get; set; }
        public string GstNo { get; set; }
        //communication
        //public string mobilePhone { get; set; }
        public string OfficeContact { get; set; }
        //public string personalEmail { get; set; }
        public string workEmail { get; set; }
        //bill Address
        public string BillAddress { get; set; }
        //public string line1 { get; set; }
        //public string line2 { get; set; }
        //public string city { get; set; }
        //public string state { get; set; }
        //public string zip { get; set; }
        public string description { get; set; }
        public string user { get; set; }

    }
}