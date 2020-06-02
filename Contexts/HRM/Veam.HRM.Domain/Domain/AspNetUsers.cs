namespace HR.Entity
{
    using System.ComponentModel.DataAnnotations;


    public partial class AspNetUsers
    {
       public AspNetUsers()
        {
            //ApprovalLevelUsers = new HashSet<ApprovalLevelUser>();
        }

      
        public string Id { get; set; }

        public int OrganisationId { get; set; }

        public int? PersonnelId { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        public virtual Organisation Organisation { get; set; }

        public virtual Personnel Personnel { get; set; }

        //public virtual ICollection<ApprovalLevelUser> ApprovalLevelUsers { get; set; }
    }
}
