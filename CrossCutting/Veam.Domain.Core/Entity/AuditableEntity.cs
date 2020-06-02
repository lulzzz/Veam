using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veam.Domain.Core.Entity
{
   public class AuditableEntity: EntityBaseWithTypedId<Guid>
    {
        public bool IsActive { get; set; }

        // Create Event
        [Display(Name = "Created At")]
        public DateTimeOffset? createdAt { get;private set; }

        [Display(Name = "Created By")]
        public string createdBy { get; private set; }

        // change Event
        [Display(Name = "Modified At")]
        public DateTimeOffset? modifiedAt { get; private set; }

        [Display(Name = "Modified By")]
        public string modifiedBy { get; private set; }


        protected void CreateAuditInfo(string user)
        {

            this.IsActive = true;
            this.createdAt = DateTime.Now;
            this.createdBy = user;
        }
        protected void UpdateAuditInfo(string user)
        {

            this.IsActive = true;
            modifiedAt = DateTime.Now;
            modifiedBy = user;
        }
        protected void SoftDelete(string user)
        {

            IsActive = false;
            modifiedAt = DateTime.Now;
            modifiedBy = user;

        }
    }
}
