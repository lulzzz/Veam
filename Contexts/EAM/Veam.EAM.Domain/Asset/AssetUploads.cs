namespace Veam.EAM.Domain
{
    public class AssetUploads
    {
        public long assetId { get; set; }
        public Asset asset { get; set; }
        public long FileId { get; set; }
        public FileDetails files { get; set; }
    }
}