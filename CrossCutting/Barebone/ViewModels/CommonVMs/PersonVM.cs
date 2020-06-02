using System.ComponentModel.DataAnnotations;

namespace Barebone.ViewModels
{
    public class Person2VM
    {
        [Display(Name = "First Name")]
        [Required]
        [StringLength(20)]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(20)]
        public string lastName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(20)]
        public string middleName { get; set; }

        [Display(Name = "Nick Name")]
        [StringLength(20)]
        public string nickName { get; set; }

        [Display(Name = "Gender")]
        public Gender gender { get; set; }

        [Display(Name = "Salutation")]
        public Salutation salutation { get; set; }
    }

    public enum Salutation
    {
        Mr,
        Mrs,
    }

    public enum Gender
    {
        Male,
        Female
    }
}
