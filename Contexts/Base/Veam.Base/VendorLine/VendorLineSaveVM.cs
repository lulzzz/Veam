namespace Veam.Base.ViewModels
{
    public class VendorLineSaveVM
    {

        public long vendorLineId { get; set; }

        public string jobTitle { get; set; }
        //person
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string nickName { get; set; }
        public string gender { get; set; }
        public string salutation { get; set; }
        //communication
        public string mobilePhone { get; set; }
        public string officePhone { get; set; }
        public string personalEmail { get; set; }
        public string workEmail { get; set; }

        //nav
        public long vendorId { get; set; }
        public string user { get; set; }

    }
    public enum Salutation
    {
        Mr,
        Mrs,
    }

    public enum Gender
    {
        Male,
        Female
    }

}