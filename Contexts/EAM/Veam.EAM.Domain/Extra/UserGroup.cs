using System.ComponentModel.DataAnnotations.Schema;

namespace Veam.EAM.Domain
{
    public class UserGroup
    {
        public int UserId { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
