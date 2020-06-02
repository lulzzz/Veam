namespace Veam.CenterRent.Domain
{

    /// <summary>
    /// Aggregate Roots
    /// </summary>
    public class RentAgreements
    {

        public double Id { get; set; }

        #region property
        public AgreementDates agreementDates { get; set; }
        public RentMaintenanceCharges rentMaintenance { get; set; }
        public RentIncrement rentIncrement { get; set; }
        /// <summary>
        /// Any Reouccring other Charge if any 
        /// </summary>
        public double OtherCharges { get; set; }
        /// <summary>
        /// One Time Interest free security deposited to lessors
        /// It will be returned on Vacting permises
        /// </summary>
        public double SecurityDeposit { get; set; }
        public LessorPaymentDetails lessorPaymentDetails { get; set; }
        /// <summary>
        /// Notice period for vacating permises
        /// </summary>
        public string NoticePeriod { get; set; }
        /// <summary>
        /// Reasons for penality
        /// </summary>
        public string PenaltyClause { get; set; }
        /// <summary>
        /// penality in Rs or percentage
        /// </summary>
        public string Penalty { get; set; }
        /// <summary>
        /// any other details to store regarding agreement
        /// </summary>
        public string Note { get; set; }
        public RentFiles files { get; set; }
        #endregion
        public Permises permise { get; set; }
        //public IEnumerable<BrokerVM> brokers { get; set; }
        //public IEnumerable<LessorVm> lessors { get; set; }

    }

}
