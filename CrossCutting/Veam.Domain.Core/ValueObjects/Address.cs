using System;

namespace Veam.Domain.Core.ValueObjects
{
    /// <summary>
    /// Value Object, use Tostring for full Address
    /// </summary>
    public class Address : ValueObject<Address>
    {
        public string line1 { get; protected set; }
        public string line2 { get; protected set; }
        public string city { get; protected set; }
        public string state { get; protected set; }
        public string zip { get; protected set; }

        //ctors
        protected Address() { }


        public Address(string street1, string street2, string city, string state,  string zip)
        {
            this.line1 = street1 ?? throw new ArgumentNullException(nameof(street1));
            this.line2 = street2 ?? throw new ArgumentNullException(nameof(street2));
            this.city = city ?? throw new ArgumentNullException(nameof(city));
            this.state = state ?? throw new ArgumentNullException(nameof(state));
            this.zip = zip ?? throw new ArgumentNullException(nameof(zip));
        }
        /// <summary>
        /// returns string value of the address
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{line1},{line2},{city},{state}-{zip}";
        
    }
}
