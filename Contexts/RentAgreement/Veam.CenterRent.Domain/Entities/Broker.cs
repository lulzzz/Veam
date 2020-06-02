using System.Collections.Generic;

namespace Veam.CenterRent.Domain
{
    /// <summary>
    /// normally have brokerage and can charge maintence too
    /// one agrmeent can have many brokrs
    /// brokerage charged as days(rent/30)
    /// </summary>
    public class Broker
    {
        public int Id { get; set; }
        public int agreementid { get; set; }
        public IEnumerable<BrokerAgreements> agreements { get; set; }
    }
    /// <summary>
    ///  Many to Many b/w Broker RentAgreement
    /// </summary>
    public class BrokerAgreements
    {
        public int Lessorid { get; set; }
        public int AgreementId { get; set; }
    }
}
