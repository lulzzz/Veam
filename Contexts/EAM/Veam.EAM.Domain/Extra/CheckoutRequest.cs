namespace Veam.EAM.Domain
{
    public class CheckoutRequest 
    {
        public int UserId { get; set; }
        public int RequestableAssetId { get; set; }
        public Asset Asset { get; set; }
        public string RequestableType { get; set; }
        public int Quantity { get; set; }
    }
}
