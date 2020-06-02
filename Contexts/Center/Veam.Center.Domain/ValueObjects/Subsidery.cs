
using System.Collections.Generic;

namespace Veam.Centers.Domain
{
    /// <summary>
    /// Define Sub Brances of Vision Ias, Glaxy , Infinity, Paras
    /// </summary>
    public class Subsidery
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string company { get; set; }
        public List<Subsidery> SubsideryList()
        {
            List<Subsidery> ct = new List<Subsidery>() {
                new Subsidery{/*Id=1,*/company="VisionIAS"},
                new Subsidery{/*Id=2,*/company="Glaxy"},
                new Subsidery{/*Id=3,*/company="Infinity"},
                new Subsidery{/*Id=4,*/company="ParasIndia"},
             
                };
            return ct;
        }
    }

    
}