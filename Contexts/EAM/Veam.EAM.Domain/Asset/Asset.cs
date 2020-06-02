using System;
using System.Collections.Generic;
using System.Text;
using Veam.Domain.Core.Entity;

namespace Veam.EAM.Domain
{
    public class Asset : EntityBase
    {

        protected Asset() { }//for Ef


        public string assetName { get; private set; }
        public string assetTag { get; set; }
        public string serialNo { get; set; }
        public AssetModel assetModel { get; set; }
        public WarrantyInfo? warranty { get; set; }
        //long nav
        public int? assetstatusId { get; set; }
        public long? assetPurchaseId { get; protected set; }
        public AssetStatus assetstatus { get; protected set; }
        public AssetPurchase assetPurchase { get; protected set; }
        public virtual ICollection<AssetUploads> assetUploads { get; set; }

        public Asset(string assetName, string serialNo, AssetModel Model, string user)
        {
            this.assetName = assetName ?? throw new ArgumentNullException(nameof(assetName));
            this.serialNo = serialNo ?? throw new ArgumentNullException(nameof(serialNo));

            UpdateAssetModel(Model.name, Model.number, Model.brand, Model.product);
            this.assetstatusId = 1;
            if (Id == 0)
            {
                CreateAuditInfo(user);
            }
            assetUploads = new HashSet<AssetUploads>();
        }

        public void updateAssetInfo(long id, string assetName,  string serialNo, AssetModel Model, string user)
        {
            this.Id = id;
            this.assetName = assetName ?? throw new ArgumentNullException(nameof(assetName));
            this.serialNo = serialNo ?? throw new ArgumentNullException(nameof(serialNo));
            //this.assetTag = Tag;
            UpdateAssetModel(Model.name, Model.number, Model.brand, Model.product);
            UpdateAuditInfo(user);
        }
        /// <summary>
        /// give this Option to update it in detail page, and use it as view component
        /// </summary>
        /// <param name="Assetid"></param>
        /// <param name="periodinMonths"></param>
        /// <param name="startDate"></param>
        /// <param name="warrantyBy"></param>
        /// <param name="notes"></param>
        public void UpdateWarranty(long Assetid, int periodinMonths, DateTime startDate, string warrantyBy, string notes)
        {
            this.Id = Assetid;
            warranty = new WarrantyInfo(periodinMonths, startDate, warrantyBy, notes);
        }
        public Asset GenrateQrCode(long Assetid )
        {
            var QRreadModel = new Asset()
            {
                Id = Assetid,
                assetTag = assetTag, 
                serialNo=serialNo,
              
            };
            return QRreadModel;
        }

        public void ChangeAssetStatus(long Assetid, int Statusid)
        {
            this.Id = Assetid;
            this.assetstatusId = Statusid;
        }
        public void UpdateAssetPurchaseInfo(long Assetid, long assetPurchaseid)
        {
            this.Id = Assetid;
           // this.assetPurchaseId = assetPurchaseid;
        }

        //internal use
        private void UpdateAssetModel(string name, string number, string brand, string product)
        {
            assetModel = new AssetModel(name, number, brand, product);
        }

       
        private readonly ICollection<CheckOut> _chekOut = new List<CheckOut>();
        public IEnumerable<CheckOut> Checkouts => _chekOut;
         
        public AssignTo assignTo { get; protected set; }
       
        public enum AssignTo
        {
            Available=0,
            Center = 1,
            Employee = 2,
            ParentAsset = 3,
            Department = 4,
            Group = 5,

        }

        //public void CheckOutToCenter(CheckOut checkOut)
        //{
        //    checkOut.asset = this;
        //    //checkOut.CheckOutToLocation();
        //    _chekOut.Add(checkOut);
        //    //Id = Assetid;
        //    //Checkouts = _permise.Add( checkOut.CheckOutToLocation(AssetId:));
        //}

        //public void CheckOutToEmployee(int EmpId, int Deptid, int Assetid)
        //{
        //}

        // return or checkin asset

        //asset in stocks method

        //Add acessories or child Asset or checkout to parent asset mehod this will be a collection

        //add spares method no need here,
        //this method should be in maintenance

    }

}