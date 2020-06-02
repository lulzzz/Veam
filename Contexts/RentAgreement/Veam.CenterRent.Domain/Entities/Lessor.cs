﻿using System.Collections.Generic;

namespace Veam.CenterRent.Domain
{
    /// <summary>
    /// one agreement can have many lessors
    /// should ba linked with permise too
    /// </summary>
    public class Lessor
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
