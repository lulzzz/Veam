namespace Veam.EAM.Domain
{
    public class ComponentsAssets
    {
        public int UserId { get; set; }
        public int AssignedQty { get; set; }
        public int ComponentsId { get; set; }
        public Components Components { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
    }
}
