using System;
using System.Collections.Generic;
using Veam.Domain.Core.ValueObjects;

namespace Veam.EMS.Domain
{
    public  class EmployeeAddress : BaseEntity
    { 
        public Address address { get; protected set;  }
        /// <summary>
        /// Permanent and current Address Type, use it in view, enum 
        /// </summary>
        public string AddressType { get; protected set; }
        public long EmployeeId { get; protected set;  }
        public Employee Employee { get;}

        //ctor and rules
        protected EmployeeAddress() { }
          
        public EmployeeAddress(long EmpAddressId, Address address, string addressType,
            long employeeId, string user)
        {
            this.address = address ?? throw new ArgumentNullException(nameof(address));
            AddressType = addressType ?? throw new ArgumentNullException(nameof(addressType));
            EmployeeId = employeeId;
            AuditInfo(EmpAddressId,user);
            //if (EmpAddressId != 0)
            //{
            //    this.Id = EmpAddressId;
            //    UpdateAuditInfo(user);
            //}
            //else
            //{
            //    CreateAuditInfo(user);
            //}
        }
    }
}
