using System;
using System.Collections.Generic;
using System.Linq;
using Veam.Domain.Core.Entity;

namespace Veam.Centers.Domain
{
    public class Center : EntityBase
    {

        #region Properites
 
        public string centerName { get; protected set; }
        public int subsideryId { get; protected set; }
        public int centerTypeId { get; protected set; }
        public long buildingId { get; protected set; }

        public Subsidery subsidery { get; protected set; }
        public CenterType centerType { get; protected set; }
        //public Building building { get; protected set; }
      
        //Additional
        public string description { get; protected set; }
        public bool isHQ { get; protected set; }

        #endregion

        //ctor and rules
        protected Center() { }
       // public string centerAddress => $"{subsidery.company},{building.address.ToString()}";

        public Center(string centerName, int centerTypeId, int subsideryId, int buildingId, string description, bool isHQ, string user)
        {
            this.centerName = centerName ?? throw new ArgumentNullException(nameof(centerName));
          
            this.centerTypeId = centerTypeId;
            this.subsideryId = subsideryId;
            this.buildingId = buildingId;
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            this.isHQ = isHQ;
            CreateAuditInfo(user);
        }

        public void Update(long id,  string centerName, int centerTypeId, int subsideryId, int buildingId, string description, bool isHQ, string user)
        {
            this.Id = id;
            this.centerName = centerName ?? throw new ArgumentNullException(nameof(centerName));
        
            this.centerTypeId = centerTypeId;
            this.subsideryId = subsideryId;
            this.buildingId = buildingId;
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            this.isHQ = isHQ;
            UpdateAuditInfo(user);
        }

        #region  // Collections
        private readonly ICollection<Hall> _halls = new List<Hall>();
        public IEnumerable<Hall> halls => _halls;

        public void AddHall(Hall hall)
        {

            _halls.Add(hall);
        }

        public void AddHalls(IEnumerable<Hall> halls)
        {
            foreach (var hall in halls)
            {
                AddHall(hall);
            }
        }

        public void RemoveHall(Hall hall)
        {
            if (!OwnsHall(hall))
            {
                throw new ArgumentException($"Hall  does not belong to this Bill: {hall}");
            }

            if (!halls.Any(p => p.Id == hall.Id))
            {
                throw new ArgumentException($"Hall already removed from Bill: {hall}");
            }

            _halls.Remove(hall);
        }

        private bool OwnsHall(Hall hall)
        {
            return hall.centerId == Id;
        }

        #endregion
      
    }

}
//public Center(string centerName, CenterNo centerNo, CenterType centerType,
//    Company company, Address branchAddress,
//    string description, bool isHeadOffice, string user)

//{
//    this.centerName = centerName ?? throw new ArgumentNullException(nameof(centerName));
//    this.centerNo = centerNo ?? throw new ArgumentNullException(nameof(centerNo));
//    this.centerType = centerType;
//    this.company = company;
//    this.branchAddress = branchAddress ?? throw new ArgumentNullException(nameof(branchAddress));
//    this.description = description ?? throw new ArgumentNullException(nameof(description));
//    this.isHQ = isHeadOffice;
//    EntityCreateInfo(user);
//}

//public void update(Guid id, string centerName, CenterNo centerNo, CenterType centerType,
//  Company subsidery, Address branchAddress,
//  string description, bool isHQ, string user)
//{
//    this.Id = id;
//    this.centerName = centerName ?? throw new ArgumentNullException(nameof(centerName));
//    this.centerNo = centerNo ?? throw new ArgumentNullException(nameof(centerNo));
//    this.centerType = centerType;
//    this.company = subsidery;
//    this.branchAddress = branchAddress ?? throw new ArgumentNullException(nameof(branchAddress));
//    this.description = description ?? throw new ArgumentNullException(nameof(description));
//    this.isHQ = isHQ;
//    EntityUpdateInfo(user);
//}


////permise
///
