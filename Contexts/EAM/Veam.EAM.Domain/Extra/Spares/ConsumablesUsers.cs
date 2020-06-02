namespace Veam.EAM.Domain
{
    public class ConsumablesUsers 
    {
        public int UserId { get; set; }
        public int ConsumableId { get; set; }
        public Consumable Consumable { get; set; }
        public int AssignTo { get; set; }
    }
}
