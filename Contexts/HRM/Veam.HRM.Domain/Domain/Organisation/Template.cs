namespace HR.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Template")]
    public partial class Template
    {
     
        public int TemplateId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }

        public int OrganisationId { get; set; }

        public virtual Organisation Organisation { get; set; }
    }
}
