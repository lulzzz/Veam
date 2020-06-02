using System;
using System.Collections.Generic;
using System.Linq;
using Veam.Domain.Core.Entity;

namespace Veam.EAM.Domain
{
    public class AssetPurchase : EntityBase
    {

       
        public BillDetails assetBills { get; set; }
    
        public long vendorId { get; protected set; }
        public string notes { get; set; }
        public virtual ICollection<PurchaseFiles> purchaseFiles { get; set; }
        //for Ef
        protected AssetPurchase() { }
        //methods

        public AssetPurchase(string billNo, DateTime billedDate, string notes,
             long vendorId, string user)
        {
            this.vendorId = vendorId ;
            this.notes = notes;
            this.assetBills = new BillDetails(billNo, billedDate);
            CreateAuditInfo(user);
            _assets = new List<Asset>();
            purchaseFiles = new HashSet<PurchaseFiles>();
        }

        public void updatePurchaseDetails(long id, string billNo, DateTime billedDate, string notes,
          long vendorId, string user)
        {
            this.Id = id;
            this.notes = notes;
            this.vendorId = vendorId;
            this.assetBills = new BillDetails(billNo, billedDate);
            CreateAuditInfo(user);
          
        }


        public void UploadBillCopy(long id, string fileName, string fileSize, string fileNotes, string fileurl)
        {
            Id = id;
         //   this.billCopy = new FileDetails(fileName, fileSize, fileNotes, fileurl);
        }

        #region  Collections
        private readonly ICollection<Asset> _assets = new List<Asset>();
        public IEnumerable<Asset> Assets => _assets;

        public void AddAsset(Asset asset)
        {
            _assets.Add(asset);
        }

        public void AddAssets(IEnumerable<Asset> assets)
        {
            foreach (var asset in assets)
            {
                AddAsset(asset);
            }
        }

        public void RemoveAsset(Asset asset)
        {
            if (!OwnsAsset(asset))
            {
                throw new ArgumentException($"Asset  does not belong to this Bill: {asset}");
            }

            if (!Assets.Any(p => p.Id == asset.Id))
            {
                throw new ArgumentException($"Asset already removed from Bill: {asset}");
            }

            _assets.Remove(asset);
        }

        private bool OwnsAsset(Asset asset)
        {
            return asset.assetPurchaseId == Id;
        }

        #endregion

    }
}