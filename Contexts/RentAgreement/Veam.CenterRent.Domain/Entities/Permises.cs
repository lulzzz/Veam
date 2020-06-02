using System.Collections.Generic;
using Veam.Domain.Core.Entity;

namespace Veam.CenterRent.Domain
{
    public class Permises: EntityBase  //list of Rented permises
    {
        public string  name { get; set; }
        public string hallNo { get; protected set; }
        public string floorNo { get; protected set; }
      
        public string description { get; protected set; }
        public string locationNo { get; set; }
        public long buildingId { get; set; }
       public Building building { get; protected set; }

        private readonly ICollection<Meters> _meters = new List<Meters>();
        public IEnumerable<Meters> meters => _meters;
    }
}
