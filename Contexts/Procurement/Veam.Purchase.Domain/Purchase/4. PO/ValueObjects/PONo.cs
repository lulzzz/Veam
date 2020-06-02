using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Veam.Common.Domain;

namespace Veam.Purchases.Domain
{
    public class PONo : ValueObject<PONo>
    {
        public PONo(string value)
        {
            Value = value;
            ThrowExceptionIfValidationFails();
        }

        private PONo()
        {
        }

        [StringLength(150, MinimumLength = 3)]
        [Required]
        // TODO: private set required by EF
        public string Value { get; private set; }

        public override string ToString()
        {
            return Value;
        }

        protected  IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        protected void ThrowExceptionIfValidationFails()
        {
            Validator.ValidateObject(this, new ValidationContext(this), true);
        }
    }

}
