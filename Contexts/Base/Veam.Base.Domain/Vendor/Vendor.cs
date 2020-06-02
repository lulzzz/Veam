using System;
using System.Collections.Generic;
using System.Linq;
using Veam.Domain.Core.Entity;
using Veam.Domain.Core.ValueObjects;

namespace Veam.Base.Domain
{
    /// <summary>
    /// defined Address, Cummunication Details and then pass it to company to make object then call vendor to add
    /// </summary>
    public partial class Vendor : EntityBase
    {

        public Company Company { get; protected set; }
        public Address BillAddress { get; protected set; }
        public Communication OfficeContact { get; protected set; }
        public string description { get; protected set; }


        protected Vendor() { }

        public Vendor(Company company, string description, string user)
        {
            Company = company ?? throw new ArgumentNullException(nameof(company));
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            CreateAuditInfo(user);
        }

        public Vendor(Company company, Address billAddress, Communication officeContact, string description, string user)
        {
            Company = company ?? throw new ArgumentNullException(nameof(company));
            BillAddress = billAddress ?? throw new ArgumentNullException(nameof(billAddress));
            OfficeContact = officeContact ?? throw new ArgumentNullException(nameof(officeContact));
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            CreateAuditInfo(user);
        }

        public void Update(long id,Company company, string description, string user)
        {
            this.Id = id;
            Company = company ?? throw new ArgumentNullException(nameof(company));
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            UpdateAuditInfo(user);
        }

        public void UpdateRegisteredAddress(long id, Address RegisteredAddress, string user)
        {
            this.Id = id;
            this.BillAddress = RegisteredAddress ?? throw new ArgumentNullException(nameof(RegisteredAddress));
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            UpdateAuditInfo(user);
        }

        public void UpdateOfficeContact(long id, Communication OfficeContact, string user)
        {
            this.Id = id;
            this.OfficeContact = OfficeContact ?? throw new ArgumentNullException(nameof(OfficeContact));
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            UpdateAuditInfo(user);
        }

        #region  // Collections
        private readonly ICollection<VendorLine> _Vlines = new List<VendorLine>(); 
        public IEnumerable<VendorLine> vendorLines => _Vlines;

        public void AddVendorLine(VendorLine data)
        {

            _Vlines.Add(data);
        }

        public void AddVendorLines(IEnumerable<VendorLine> list)
        {
            foreach (var data in list)
            {
                AddVendorLine(data);
            }
        }

        public void RemoveVendorLine(VendorLine data)
        {
            if (!OwnsVendorLine(data))
            {
                throw new ArgumentException($"Hall  does not belong to this Bill: {data}");
            }

            if (!vendorLines.Any(p => p.Id == data.Id))
            {
                throw new ArgumentException($"Hall already removed from Bill: {data}");
            }

            _Vlines.Remove(data);
        }

        private bool OwnsVendorLine(VendorLine data)
        {
            return data.vendorId == Id;
        }
        #endregion
    }
}
