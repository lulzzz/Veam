using System;

namespace Veam.CenterRent.Domain
{
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

}
