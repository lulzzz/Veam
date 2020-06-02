using System;
using Veam.Domain.Core.Entity;

namespace Veam.Centers.Domain
{
    /// <summary>
    /// used for mapping of asset
    /// </summary>
    public class Hall : EntityBase
    {

        #region Property
        public string hallName { get; protected set; }
        public string hallNo { get; protected set; }
        public string floorNo { get; protected set; }
        /// <summary>
        /// apply it command 
        /// </summary>
        public string locationNo { get; protected set; }



        public string description { get; protected set; }
        public long centerId { get; protected set; }
        #endregion

        //Nav and ref
        public Center center { get; protected set; }

        //ctor and Methods
        protected Hall() { }

        public Hall(string hallName, string hallNo, string floorNo, string locationNo,
            string description, long centerId, string user)
        {
            this.hallName = hallName ?? throw new ArgumentNullException(nameof(hallName));
            this.hallNo = hallNo;
            this.floorNo = floorNo;
            this.description = description;
            this.centerId = centerId;
            this.locationNo = locationNo;
            CreateAuditInfo(user);
        }

        public void Update(long id, string hallName, string hallNo, string floorNo, string locationNo,
            string description, long centerId, string user)
        {
            this.Id = id;
            this.hallName = hallName ?? throw new ArgumentNullException(nameof(hallName));
            this.hallNo = hallNo;
            this.floorNo = floorNo;
            this.description = description;
            this.centerId = centerId;
            this.locationNo = locationNo;
            UpdateAuditInfo(user);
        }
       
    }
}

//private string locNo;
//public string locationNo
//{
//    get { return locNo; }
//    protected set
//    {
//        value = $"{center.building.buildingNo}{this.hallNo}";
//        locNo = value;
//    }
//}