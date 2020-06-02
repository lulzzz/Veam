
using System.Collections.Generic;

namespace Veam.RentAgreement.ViewModels
{
    /// <summary>
    /// An unit for RentAgreement ! 
    /// and can have many Facilty
    /// </summary>
    public class PermisesVM
    {
        public string Id { get; set; }
      //  public BuildingsVM building { get; set; }
        public string floorNo { get; set; }
        public string hallNo { get; set; }

        public IEnumerable<MetersVM> meters { get; set; }
    }

}
