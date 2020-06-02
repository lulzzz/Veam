using System;
using System.Collections.Generic;
using System.Linq;
using Veam.Domain.Core.Entity;
using Veam.Domain.Core.ValueObjects;

namespace Veam.CenterRent.Domain
{
    /// <summary>
    /// Common unit For CenterMap and Permises of Rent Agreement
    /// </summary>
    public class Building : EntityBase
    {
        public string buildingName { get; private set; }
        public string buildingNo { get;private  set; }
        public Address address { get; private set; }
        protected Building() { }

        public Building(string buildingName, string buildingNo, Address address,string user)
        {
            
            this.buildingName = buildingName ?? throw new ArgumentNullException(nameof(buildingName));
            this.buildingNo = buildingNo ?? throw new ArgumentNullException(nameof(buildingNo));
            this.address = address ?? throw new ArgumentNullException(nameof(address));
            CreateAuditInfo(user);
        }
      
        
        /// <summary>
        /// availble via obj though ef context
        /// </summary>
        /// <param name="id"></param>
        /// <param name="buildingName"></param>
        /// <param name="buildingNo"></param>
        /// <param name="address"></param>
        /// <param name="user"></param>
        public  void Update(long id,string buildingName, string buildingNo, Address address, string user)
        {
            this.Id = id;
            this.buildingName = buildingName ?? throw new ArgumentNullException(nameof(buildingName));
            this.buildingNo = buildingNo ?? throw new ArgumentNullException(nameof(buildingNo));
            this.address = address ?? throw new ArgumentNullException(nameof(address));
            UpdateAuditInfo(user);
        }

        #region Collections

        private readonly ICollection<Permises> _permise = new List<Permises>();
        public IEnumerable<Permises> Permises => _permise;
        public void AddPermise(Permises permise)
        {

            _permise.Add(permise);
        }

        public void AddPermises(IEnumerable<Permises> permises)
        {
            foreach (var permise in permises)
            {
                AddPermise(permise);
            }
        }

        public void RemovePermises(Permises permise)
        {
            if (!OwnsPermises(permise))
            {
                throw new ArgumentException($"Hall  does not belong to this Bill: {permise}");
            }

            if (!Permises.Any(p => p.Id == permise.Id))
            {
                throw new ArgumentException($"Hall already removed from Bill: {permise}");
            }

            _permise.Remove(permise);
        }

        private bool OwnsPermises(Permises permise)
        {
            return permise.buildingId == Id;
        }
        #endregion

    }
}
