using System;
using Veam.Domain.Core.ValueObjects;

namespace Veam.Domain.Core.ValueObjects
{
    /// <summary>
    /// value Object with Email and Phone no
    /// </summary>
    public class Communication : ValueObject<Communication>
    {
        public Communication(string mobilePhone, string officePhone, string personalEmail, string workEmail)
        {
            this.mobilePhone = mobilePhone ?? throw new ArgumentNullException(nameof(mobilePhone));
            this.officePhone = officePhone ?? throw new ArgumentNullException(nameof(officePhone));
            this.personalEmail = personalEmail ?? throw new ArgumentNullException(nameof(personalEmail));
            this.workEmail = workEmail ?? throw new ArgumentNullException(nameof(workEmail));
        }

        public string mobilePhone { get; protected set; }
        public string officePhone { get; protected set; }
        public string personalEmail { get; protected set; }
        public string workEmail { get; protected set; }

        public override string ToString() => $"/n{officePhone}/n/n {mobilePhone}/n/n{workEmail}";
      
        
    }
}
