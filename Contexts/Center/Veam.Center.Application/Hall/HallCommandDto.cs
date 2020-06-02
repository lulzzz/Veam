namespace Veam.Centers.Application.CenterMap
{
    public class HallCommandDto
    {
       // public long hallId { get; set; }
        public string hallName { get; set; }
        public string hallNo { get; set; }
        public string floorNo { get; set; }
        public string locationNo { get; set; }
        public string description { get; set; }
        public string user { get; set; }
        /// <summary>
        /// fk
        /// </summary>
        public long centerId { get; set; }

    }

}

