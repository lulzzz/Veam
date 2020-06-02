namespace Veam.EAM.Domain
{
    public class AccessoriesUsers 
    {
        public int AccessoryId { get; set; }
        public Accessory Accessory { get; set; }
        public int AssignTo { get; set; }
       
    }
}
