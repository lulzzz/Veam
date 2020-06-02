namespace Veam.Base.ViewModels
{
    public class VendorLineQueryVM
    {

        public int vendorLineId { get; set; }

        public string jobTitle { get; set; }
        //person
      

        public string ContactFullName { get; set; }
        //communication
        public string mobilePhone { get; set; }
        public string officePhone { get; set; }
        public string personalEmail { get; set; }
        public string workEmail { get; set; }


        public int vendorId { get; set; }
        public int vendorName { get; set; }
        public string user { get; set; }

    }

}