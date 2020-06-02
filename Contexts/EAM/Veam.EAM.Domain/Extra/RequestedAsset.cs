using System;
using System.ComponentModel.DataAnnotations;

namespace Veam.EAM.Domain
{
    public class RequestedAsset
    {
        public int AssetId { get; set; }
        public Asset  Asset { get; set; }
        public int UserId { get; set; }
    
        public DateTime AcceptedAt { get; set; }

        public DateTime DeniedAt { get; set; }
        public string Note { get; set; }
    }
}
