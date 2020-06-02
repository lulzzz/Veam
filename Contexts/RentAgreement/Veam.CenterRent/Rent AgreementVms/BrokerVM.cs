
using System.Collections.Generic;

namespace Veam.RentAgreement.ViewModels
{
    /// <summary>
    /// normally have brokerage and can charge maintence too
    /// one agrmeent can have many brokrs
    /// brokerage charged as days(rent/30)
    /// </summary>
    public class BrokerVM
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
