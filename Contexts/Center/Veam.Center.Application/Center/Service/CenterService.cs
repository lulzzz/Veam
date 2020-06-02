using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.Centers.Domain;

namespace Veam.Centers.Application
{
    public class CenterService : ICenterService
    {
        private readonly ICenterDbContext _context;
        public CenterService(ICenterDbContext context)
        {
            _context = context;
        }
        

        public async Task<Center> GetByIdAsync(long? id)
        {
            return await _context.Center.FindAsync(id);
        }

        public IEnumerable<Subsidery> GetSubsideries()
        {
           
             return _context.Subsideries.ToList();
        }

        public IEnumerable<CenterType> GetCenterTypes()
        {
            return _context.CenterTypes.ToList();
        }
    }
}