using System;
using System.ComponentModel.DataAnnotations;

namespace Veam.Infrastructure.CoreEntity
{
    public class VeamBasicEntity
    {
     
        
        public Int32 Id { get; set; }
       
        // for Soft Delete
        public bool IsActive { get; set; }
       
        // Create Event
        [Display(Name = "Created At")]
        public DateTimeOffset? createdAt { get; set; }

        [Display(Name = "Created By")]
        public string createdBy { get; set; }

        // change Event
        [Display(Name = "Modified At")]
        public DateTimeOffset? modifiedAt { get; set; }

        [Display(Name = "Modified By")]
        public string modifiedBy { get; set; }


        protected  void EntityCreateInfo(string user)
        {

           this.IsActive = true;
            this.createdAt = DateTime.Now;
            this.createdBy = user;
        }

        protected void EntityUpdateInfo(string user)
        {

            this.IsActive = true;
            modifiedAt = DateTime.Now;
            modifiedBy = user;
        }
        protected  void softDelete(string user)
        {

            IsActive = false;
            modifiedAt = DateTime.Now;
            modifiedBy = user;
            
        }
    }
}