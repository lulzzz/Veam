using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.Centers.Domain;

namespace Veam.Centers.Application
{
    public class HallService : IHallService
    {
        private readonly ICenterDbContext _context;

        public HallService(ICenterDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Hall> GetListByMaserId(long? masterid)
        {
            return _context.Hall.Include(x=>x.center).Where(x => x.centerId.Equals(masterid)).ToList();
        }



        public async Task<Hall> GetByIdAsync(long? id)
        {
            return await _context.Hall.Include(x => x.center).FirstAsync(x=>x.Id.Equals(id)) ;
        }

        public async Task<IEnumerable<Hall>> GetList()
        {
            return await _context.Hall.Include(x=>x.center).ToListAsync();
        }

        public IEnumerable<Center> GetCenterList()
        {
            return _context.Center.ToList();
        }

        public IQueryable<Hall> GetListqery()
        {
            return  _context.Hall.Include(x => x.center);
        }
    }
}
