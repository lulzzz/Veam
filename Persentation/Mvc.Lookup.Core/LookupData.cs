using System;
using System.Collections.Generic;

namespace NonFactors.Mvc.Lookup
{
    public class LookupData
    {
        public IList<LookupColumn> Columns { get; set; }
        public List<Dictionary<String, String?>> Rows { get; set; }
        public List<Dictionary<String, String?>> Selected { get; set; }

        public LookupData()
        {
            Columns = new List<LookupColumn>();
            Rows = new List<Dictionary<String, String?>>();
            Selected = new List<Dictionary<String, String?>>();
        }
    }
}
