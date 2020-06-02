using System;
using System.Collections.Generic;
using System.Text;

namespace Veam.Base.Application
{
    public class VendorCommandDto
    {
        public string RegisterCompanyName { get; set; }
        public string Country { get; set; }
        public string GstNo { get; set; }
        //communication
        public string mobilePhone { get; set; }
        public string officePhone { get; set; }
        public string personalEmail { get; set; }
        public string workEmail { get; set; }
        //bill Address
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string description { get; set; }
        public string user { get; set; }
    }

}

