using System.Threading.Tasks;

namespace Veam.Services
{
    public interface IDbInitService
    {
        Task InitDemo();
        //VMStock GetStockByProductAndWarehouse(string productId, string warehouseId);

        //List<VMStock> GetStockPerWarehouse();
    }
}
