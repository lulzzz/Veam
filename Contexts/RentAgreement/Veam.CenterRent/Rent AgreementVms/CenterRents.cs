using System;

namespace Veam.RentAgreement.ViewModels
{



    /// <summary>
    /// value object All dates and period , Estamp, Agreemnt, start, period etc data
    /// </summary>
    public class AgreementDatesVM
    {
        /// <summary>
        /// Date of E stamp paper
        /// </summary>
        public DateTime EstampDate { get; set; }
        /// <summary>
        /// Actual Agreement signing Date
        /// </summary>
        public DateTime AgreementDate { get; set; }
        /// <summary>
        /// Rent Starting Date
        /// </summary>
        public DateTime RentStartingDate { get; set; }

        /// <summary>
        /// Agreement period Like 5 years
        /// </summary>
        public string Period { get; set; }
        /// <summary>
        /// Agreement End Date, Rent Agreement should be renewed before this date
        /// it Is equal to Starting Date + period
        /// </summary>
        public DateTime AgreementEndingDate { get; set; }

        /// <summary>
        /// for alert purpose. from this date process of renew agreement should be started
        /// Idealy 1 month before Ending Date
        /// </summary>
        public DateTime RenewalDate { get; set; }


        /// <summary>
        /// It is charged by govt for agreement . tax + vakil Fees
        /// shared equally b/w lessor and lessee. At the time of Agreement
        /// </summary>
        public double StampDuty { get; set; }
    }

    /// <summary>
    /// Maintenace Charges related Data Value object
    /// </summary>
    public class RentMaintenanceCharges
    {
        public double InitMaintenceCharges { get; set; }
        public decimal RateofIncrement { get; set; }
        public string incrementPeriodinMonths { get; set; }
        public DateTime IncrementMonth { get; set; }
        public string scopeIncludes { get; set; }
    }
    /// <summary>
    /// Rent Increment Details Value Object
    /// </summary>
    public class RentIncrement
    {
        public DateTime RentDueDate { get; set; }
        public double StartingRent { get; set; }
        public decimal RateofIncrement { get; set; }
        public string incrementPeriodinYrs { get; set; }
        public DateTime IncrementMonth { get; set; }
        public double CurrentRent { get; set; }
    }

    /// <summary>
    /// all the documnts related to Rent
    /// </summary>
    public class RentFiles
    {

        public string Note { get; set; }
        public string Files { get; set; }

    }
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



    /// <summary>
    /// Aggregate Roots
    /// </summary>
    public class RentAgreementVM
    {

        public double Id { get; set; }

        #region property
        public AgreementDatesVM agreementDates { get; set; }
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
      //  public Permises permise { get; set; }
        //public IEnumerable<BrokerVM> brokers { get; set; }
        //public IEnumerable<LessorVm> lessors { get; set; }

    }

}
