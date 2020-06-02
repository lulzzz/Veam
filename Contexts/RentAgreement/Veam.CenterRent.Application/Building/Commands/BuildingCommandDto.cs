namespace Veam.CenterRent.Application
{
    public class BuildingCommandDto
    {
        public long buildingId { get; set; }
        public string buildingName { get; set; }
        public string buildingNo { get; set; }
        //address
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
