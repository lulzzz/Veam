using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Veam.Base.Domain;
using Veam.Centers.Domain;
using Veam.CenterRent.Domain;
using Veam.Data;
using Veam.EAM.Domain;

namespace Veam.Services
{
    public class DbInitService : IDbInitService
    {
        private readonly DataDbContext _context;
        public DbInitService(DataDbContext context)
        {
            _context = context;
        }
       
        public async Task InitDemo()
        {

          //  _context.Database.OpenConnection();
            try
            {
                //var ctl = new CenterType().CenterTypesList();
                //_context.AddRange(ctl);

                var subl = new Subsidery().SubsideryList();
                _context.AddRange(subl);

                var productCat = new ProductCategory().ProductCategoryList();
                _context.AddRange(productCat);

                var prodType = new ProductType().ProductTypeList();
                _context.AddRange(prodType);

                var Assetstaus = new AssetStatus().StatusList();
                _context.AddRange(Assetstaus);

                var MeterType = new MeterType().MeterTypesList();
                _context.AddRange(MeterType);

                var ctl = new CenterType().CenterTypesList();
                _context.AddRange(ctl);
                  _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _context.Database.CloseConnection();
            }

         
        }

    }
}
//public VMStock GetStockByProductAndWarehouse(string productId, string warehouseId)
//{
//    VMStock result = new VMStock();

//    try
//    {
//        Product product = _context.Product.Where(x => x.productId.Equals(productId)).FirstOrDefault();
//        Warehouse warehouse = _context.Warehouse.Where(x => x.warehouseId.Equals(warehouseId)).FirstOrDefault();

//        if (product != null && warehouse != null)
//        {
//            VMStock stock = new VMStock();
//            stock.Product = product.productCode;
//            stock.Warehouse = warehouse.warehouseName;
//            stock.QtyReceiving = _context.ReceivingLine.Where(x => x.productId.Equals(product.productId) && x.warehouseId.Equals(warehouse.warehouseId)).Sum(x => x.qtyReceive);
//            stock.QtyShipment = _context.ShipmentLine.Where(x => x.productId.Equals(product.productId) && x.warehouseId.Equals(warehouse.warehouseId)).Sum(x => x.qtyShipment);
//            stock.QtyTransferIn = _context.TransferInLine.Where(x => x.productId.Equals(product.productId) && x.transferIn.warehouseIdTo.Equals(warehouse.warehouseId)).Sum(x => x.qty);
//            stock.QtyTransferOut = _context.TransferOutLine.Where(x => x.productId.Equals(product.productId) && x.transferOut.warehouseIdFrom.Equals(warehouse.warehouseId)).Sum(x => x.qty);
//            stock.QtyOnhand = stock.QtyReceiving + stock.QtyTransferIn - stock.QtyShipment - stock.QtyTransferOut;

//            result = stock;
//        }


//    }
//    catch (Exception)
//    {

//        throw;
//    }

//    return result;

//}

/// <summary>
/// get stock
/// </summary>
/// <returns></returns>
//public List<VMStock> GetStockPerWarehouse()
//{
//    List<VMStock> result = new List<VMStock>();

//    try
//    {
//        List<VMStock> stocks = new List<VMStock>();
//        List<Product> products = new List<Product>();
//        List<Warehouse> warehouses = new List<Warehouse>();
//        warehouses = _context.Warehouse.ToList();
//        products = _context.Product.ToList();
//        foreach (var item in products)
//        {
//            foreach (var wh in warehouses)
//            {
//                VMStock stock = stock = GetStockByProductAndWarehouse(item.productId, wh.warehouseId);

//                if (stock != null) stocks.Add(stock);

//            }


//        }

//        result = stocks;
//    }
//    catch (Exception)
//    {

//        throw;
//    }

//    return result;
//}