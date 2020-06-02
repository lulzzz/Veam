using System;

namespace NonFactors.Mvc.Lookup
{
    public class LookupException : Exception
    {
        public LookupException(String message)
            : base(message)
        {
        }
    }
}
