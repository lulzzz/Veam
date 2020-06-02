namespace HR.Entity
{

    public partial class AspNetUsersAlertSchedule
    {
        public int AspnetUsersAlertScheduleId { get; set; }

     
        public string AspNetUsersId { get; set; }

        public int AlertId { get; set; }

        public virtual Alert Alert { get; set; }
    }
}
