namespace Veam.EAM.Domain
{
    public class Requests
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int UserId { get; set; }
        public string RequestedCode { get; set; }
    }
}
