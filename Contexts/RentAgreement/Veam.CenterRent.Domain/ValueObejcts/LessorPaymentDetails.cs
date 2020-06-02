namespace Veam.CenterRent.Domain
{
    /// <summary>
    /// lessor payment Details
    /// </summary>
    public class LessorPaymentDetails
    {
        public string PaymentMode { get; set; }
        public string AccountDetails { get; set; }
        public string GstDetails { get; set; }
        public string PropertyTaxSlip { get; set; }
    }

}
