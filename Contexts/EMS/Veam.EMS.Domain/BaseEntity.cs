using System;
using System.Collections.Generic;
using System.Text;
using Veam.Domain.Core.Entity;

namespace Veam.EMS.Domain
{
    public class BaseEntity: EntityBase
    {
        public void AuditInfo(long Id,string user)
        {
            if (Id != 0)
            {
                this.Id = Id;
                UpdateAuditInfo(user);
            }
            else
            {
                CreateAuditInfo(user);
            }
        }
    }
}
