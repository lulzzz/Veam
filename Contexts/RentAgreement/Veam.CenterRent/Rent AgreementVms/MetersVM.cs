namespace Veam.RentAgreement.ViewModels
{
    /// <summary>
    /// Meter Details with charing Company likes Bses, Tpddl
    /// a permises Can have many meters
    /// </summary>
    public class MetersVM
    {
        public int Id { get; set; }
        public PermisesVM permise { get; set; }
        public MeterTypeVM meterType { get; set; }
        public string MeterNo { get; set; }
    }
    /// <summary>
    /// Entity or Enum for Defining Meter Type
    /// Like Water meter, Electricity meter etc.
    /// </summary>
    public class MeterTypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MetertypeNo { get; set; }

    }
}
