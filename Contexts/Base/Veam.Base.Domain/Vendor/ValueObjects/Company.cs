using System;
using Veam.Domain.Core.ValueObjects;

namespace Veam.Base.Domain
{
    /// <summary>
    /// Value Object for Comapny Details,

    /// </summary>
    public class Company : ValueObject<Company>
    {
        private Company()
        {

        }
        public Company(string registerCompanyName, string country, string gstNo)
        {
            RegisterCompanyName = registerCompanyName ?? throw new ArgumentNullException(nameof(registerCompanyName));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            GstNo = gstNo /*?? throw new ArgumentNullException(nameof(gstNo))*/;
        }

        public string RegisterCompanyName { get; protected set; }
        public string Country { get; protected set; }
        public string GstNo { get; protected set; }
      
        public override string ToString() => $"{RegisterCompanyName} /n/n Gst NO:-{GstNo}";
       
    }
}
