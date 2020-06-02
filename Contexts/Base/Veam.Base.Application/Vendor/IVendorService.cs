using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public interface IVendorService
    {
        Task<Vendor> GetByIdAsync(long? id);
        Task<IEnumerable<Vendor>> GetVendorListAsync();
        IEnumerable<VendorLine> GetVendorLineList();
        Task<IEnumerable<Vendor>> GetListAsync();
    }

    public class VendorService : IVendorService
    {
        private readonly IBaseDbContext _context;
        public VendorService(IBaseDbContext context)
        {
            _context = context;
        }


        public async Task<Vendor> GetByIdAsync(long? id)
        {
            var entity = await _context.Vendor.FindAsync(id);

            return entity;
        }

        public async Task<IEnumerable<Vendor>> GetListAsync()
        {
            var entity = await _context.Vendor.ToListAsync();

            return entity;
        }

        public IEnumerable<VendorLine> GetVendorLineList()
        {
            var entity = _context.VendorLine.ToList();

            return entity;
        }

        public IEnumerable<Vendor> GetVendorList()
        {
            var entity = _context.Vendor.ToList();

            return entity;
        }

        public async Task<IEnumerable<Vendor>> GetVendorListAsync()
        {
            var entity = await _context.Vendor.ToListAsync();

            return entity;
        }
    }
}