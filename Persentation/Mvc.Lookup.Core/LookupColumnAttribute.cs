using System;

namespace NonFactors.Mvc.Lookup
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class LookupColumnAttribute : Attribute
    {
        public Boolean Filterable { get; set; }
        public Int32 Position { get; set; }
        public Boolean Hidden { get; set; }
        public String? Format { get; set; }

        public LookupColumnAttribute()
        {
            Filterable = true;
        }
        public LookupColumnAttribute(Int32 position)
        {
            Filterable = true;
            Position = position;
        }
    }
}
