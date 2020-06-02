
using System.ComponentModel;

namespace HR.Entity
{
    using Interfaces;

    // //[MetadataType(typeof(SiteMetadata))]
    public partial class Site : IOrganisationFilterable
    {
        private class SiteMetadata
        {

            [DisplayName("Organisation")]
            public int? OrganisationId { get; set; }

            [DisplayName("Site Id")]
            public int SiteId { get; set; }

            [DisplayName("Country")]
            public int CountryId { get; set; }
        }
    }
}
