using Veam.Core.Domain;

namespace Veam.EAM.Domain
{
    public class location
    {
        public int centerId { get;  set; }
        public int hallId { get;  set; }
        public string locationNo { get; set; }
        public long Incharge { get; set; }
        public Employee InchargeId { get; set; }
    }

  
}
