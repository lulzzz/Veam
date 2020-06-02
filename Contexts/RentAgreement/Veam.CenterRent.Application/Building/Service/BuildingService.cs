using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veam.CenterRent.Domain;

namespace Veam.CenterRent.Application
{
    public class BuildingService : IBuildingServices
    {
        private readonly IRentDbContext _context;
       
        public BuildingService(IRentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Building>> GetAllAsync()
        {

            var entity = await _context.Building.ToListAsync();
          
            return entity;
        }

        public async Task<Building> GetByIdAsync(long? id)
        {
            var entity = await _context.Building.FindAsync(id);
         
            return entity;
        }
        public async Task<Building> GetEditAsync(long? id)
        {
            var entity = await _context.Building.FindAsync(id);
         
            return entity;
        }
    }
}
