using System.Collections.Generic;

namespace Veam.EAM.Domain
{
    /// <summary>
    /// entity status
    /// </summary>
    public class AssetStatus
    {
        public int Id { get; set; }
        public string status { get; set; }

        public List<AssetStatus> StatusList()
        {
            List<AssetStatus> ct = new List<AssetStatus>()
            {
               //  new AssetStatus{Id=1,status="Ne"},
                new AssetStatus{/*Id=1,*/status="InStock"},
                new AssetStatus{/*Id=2,*/status="Assigned"},
                new AssetStatus{/*Id=3,*/status="InMaintenance"},
                new AssetStatus{/*Id=4,*/status="Archived"},
            };
            return ct;
        }
    }
}