using System.ComponentModel.DataAnnotations;

namespace Veam.EAM.Domain
{
    public class Group 
    {
        [Display(Name ="Group Name")]
        public string Name { get; set; }
        public string Permissions { get; set; }
    }
}
