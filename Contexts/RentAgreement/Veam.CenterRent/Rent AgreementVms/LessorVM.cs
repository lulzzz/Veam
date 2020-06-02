
using System.Collections.Generic;

namespace Veam.RentAgreement.ViewModels
{
    /// <summary>
    /// one agreement can have many lessors
    /// should ba linked with permise too
    /// </summary>
    public class LessorVM
    {
        public int id { get; set; }
        public IEnumerable<LessorAgreements> agreements { get; set; }
    }
    /// <summary>
    ///  Many to Many b/w lessor RentAgreement
    /// </summary>
    public class LessorAgreements
    {
        public int Lessorid { get; set; }
        public int AgreementId { get; set; }
    }
}
