using System.Collections.Generic;

namespace Veam.CenterRent.Domain
{
    /// <summary>
    /// Meter Details with charing Company likes Bses, Tpddl
    /// a permises Can have many meters
    /// </summary>
    public class Meters
    {
        public int Id { get; set; }
        public Permises permise { get; set; }
        public MeterType meterType { get; set; }
        public string MeterNo { get; set; }
        public string Capacity { get; set; }
        //public string  FirstReading { get; set; }
    }

    /// <summary>
    /// Entity or Enum for Defining Meter Type
    /// Like Water meter, Electricity meter etc.
    /// </summary>
    public class MeterType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MetertypeNo { get; set; }
        public List<MeterType> MeterTypesList()
        {
            List<MeterType> ct = new List<MeterType>()
            { 
                new MeterType{Name="Water Mater",MetertypeNo="KNO"},
                new MeterType{Name="Electricity Meter",MetertypeNo="CANO"},
               
            };
            return ct;
        }

    }

}
