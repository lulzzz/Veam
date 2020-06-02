using System;
using System.Collections.Generic;

namespace NonFactors.Mvc.Lookup
{
    public class LookupFilter
    {
        public IList<String> Ids { get; set; }
        public IList<String> CheckIds { get; set; }
        public IList<String> Selected { get; set; }

        public String? Search { get; set; }

        public String? Sort { get; set; }
        public LookupSortOrder Order { get; set; }

        public Int32 Rows { get; set; }
        public Int32 Offset { get; set; }

        public IDictionary<String, Object?> AdditionalFilters { get; set; }

        public LookupFilter()
        {
            Ids = new List<String>();
            CheckIds = new List<String>();
            Selected = new List<String>();
            AdditionalFilters = new Dictionary<String, Object?>();
        }
    }
}
