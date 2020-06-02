using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public interface IVendorLineService
    {
        Task<IEnumerable<VendorLine>> GetList();
        IEnumerable<VendorLine> GetListByMaserId(long? masterid);
        Task<VendorLine> GetByIdAsync(long? id);
        Vendor GetBymasterId(long? masterid);
        VendorLine GetById(long? id);
    }
    public class VendorLineService : IVendorLineService
    {
        private readonly IBaseDbContext _context;

        public VendorLineService(IBaseDbContext context)
        {
            _context = context;
        }

        public IEnumerable<VendorLine> GetListByMaserId(long? masterid)
        {
            return _context.VendorLine.Where(x => x.vendorId.Equals(masterid)).ToList();
        }



        public async Task<VendorLine> GetByIdAsync(long? id)
        {
            return await _context.VendorLine.FindAsync(id);
        }

        public async Task<IEnumerable<VendorLine>> GetList()
        {
            return await _context.VendorLine.ToListAsync();
        }

        public Vendor GetBymasterId(long? masterid)
        {
           return _context.Vendor.SingleOrDefault(m => m.Id == masterid);
        }

        public VendorLine GetById(long? id)
        {
            return _context.VendorLine.SingleOrDefault(m => m.Id == id);
        }
    }
}
