using System;

namespace NonFactors.Mvc.Lookup
{
    public class LookupColumn
    {
        public String Key { get; }
        public String Header { get; set; }
        public Boolean Hidden { get; set; }
        public String CssClass { get; set; }
        public Boolean Filterable { get; set; }

        public LookupColumn(String key, String header)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Header = header;
            CssClass = "";
        }
    }
}
