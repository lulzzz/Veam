using System;

namespace Veam.CenterRent.Domain
{
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

}
