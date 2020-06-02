using Microsoft.EntityFrameworkCore;
using System;
using Veam.Domain.Core.ValueObjects;

namespace Veam.EAM.Domain
{
    /// <summary>
    /// Value Object
    /// </summary>
    [Owned]
    public class WarrantyInfo : ValueObject<WarrantyInfo>
    {
        /// <summary>
        /// End date calculated automatically
        /// </summary>
        /// <param name="periodinMonths"></param>
        /// <param name="startDate"></param> 
        /// <param name="warrantyBy"></param>
        /// <param name="notes"></param>
        public WarrantyInfo(int periodinMonths, DateTime StartDate, string warrantyBy, string notes)
        {
            this.periodinMonths = periodinMonths;
            this.StartDate = StartDate;
            this.EndDate = StartDate.AddMonths(periodinMonths);
            this.warrantyBy = warrantyBy;
            this.notes = notes;
        }

        public int periodinMonths { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public string warrantyBy { get; protected set; }
        public string notes { get; protected set; }
        // public int estLife { get; protected set; }
        public override string ToString() => $"its warranty will end by:-{EndDate}";

    }
}