using System;
using System.ComponentModel.DataAnnotations;

namespace Veam.Domain.Core.Entity

{
    /// <summary>
    ///  int Id with Auditable Property.  If you want an entity with a type other
    ///  than int, such as string, then use <see cref="EntityBaseWithTypedId{TId}" /> instead.
    /// </summary>
    public abstract class EntityBase : EntityBaseWithTypedId<long>
    {
        //public long Id { get; set; }
        public bool IsActive { get; set; }

        // Create Event
        [Display(Name = "Created At")]
        public DateTimeOffset? createdAt { get; private set; }

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
        protected void softDelete(string user)
        {

            IsActive = false;
            modifiedAt = DateTime.Now;
            modifiedBy = user;

        }
    }
}
