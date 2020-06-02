using System;

namespace Veam.CenterRent.Domain
{
    /// <summary>
    /// value object All dates and period , Estamp, Agreemnt, start, period etc data
    /// </summary>
    public class AgreementDates
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

}
