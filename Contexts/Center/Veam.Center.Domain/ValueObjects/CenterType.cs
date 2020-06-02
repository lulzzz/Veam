using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veam.Centers.Domain
{
    /// <summary>
    /// define Types of Hall ie Classroom, Office, testCenter
    /// </summary>
    public class CenterType
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Type { get; set; }

       public List<CenterType> CenterTypesList()
        {
            List<CenterType> ct = new List<CenterType>() {
                new CenterType{/*Id=1,*/Type="Office"},
                new CenterType{/*Id=2,*/Type="ClassRooms"},
                new CenterType{/*Id=3,*/Type="DiscussionCenter"},
                new CenterType{/*Id=4,*/Type="TestCenter"},
                new CenterType{/*Id=5,*/Type="CopyCell"},
                new CenterType{/*Id=6,*/Type="ExpertArea"},
                new CenterType{/*Id=7,*/Type="Store"},
                new CenterType{/*Id=8,*/Type="Others"}
                };
            return ct;
        }
    }
}