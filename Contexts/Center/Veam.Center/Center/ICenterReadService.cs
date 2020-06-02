using AutoMapper;
using Sequel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veam.Application.Core;
using Veam.Centers.Application;
using Veam.Centers.ViewModels;

namespace Veam.Centers.Center
{
    public interface ICenterReadService
    {
        Task<IEnumerable<CenterQueryVm>> GetAllAsync();
        Task<CenterQueryVm> GetCenterById(long id);
        IEnumerable<BuildingLookUP> GetBuilding();
    }
    public class CenterReadService : ICenterReadService
    {
        private readonly ICenterDbContext _context;
        private readonly IMapper _mapper;
        private readonly IBaseReadModelRepository _repo;
        public CenterReadService(ICenterDbContext context, IMapper mapper, IBaseReadModelRepository repo)
        {
            _context = context;
            _mapper = mapper;
            _repo = repo;
        }

      
        public async Task<IEnumerable<CenterQueryVm>> GetAllAsync()
        {
            var sqlBuilder = new SqlBuilder()
                .Select("C.Id as CenterId,C.centerName as CenterName, C.description as description," +
                "B.buildingName as buildingName, B.buildingNo as buildingNo," +
                "B.add_line1+ ','+B.add_line2+','+B.add_city+','+B.add_state+'-'+B.add_zip as Addressfull," +
                "T.Type as CenterType," +
                "S.company As Subsidery")
                .From("dbo.Center C")
                .LeftJoin("Rent.Building B", "C.buildingId=B.Id")
                .LeftJoin("dbo.CenterTypes T", "C.centerTypeId=T.Id")
                .LeftJoin("dbo.Subsideries S", "C.subsideryId=S.Id");
            string sql = sqlBuilder.ToSql();
            
            var rq =  _repo.GetAllAsync<CenterQueryVm>(sql);
           
            return await rq;
        }

     

        public async Task<CenterQueryVm> GetCenterById(long id)
        {
            var sqlBuilder = new SqlBuilder()
                .Select("C.Id as CenterId, C.centerName as CenterName, C.description as description," +
                "B.buildingName as buildingName,B.buildingNo as buildingNo ," +
                "B.add_line1+ ','+B.add_line2+','+B.add_city+','+B.add_state+'-'+B.add_zip as Addressfull," +
                "T.Type as CenterType," +
                "S.company As Subsidery")
                .From("dbo.Center C")
                .LeftJoin("Rent.Building B", "C.buildingId=B.Id")
                .LeftJoin("dbo.CenterTypes T", "C.centerTypeId=T.Id")
                .LeftJoin("dbo.Subsideries S", "C.subsideryId=S.Id")
                 .Where($"C.Id={id}");
            string sql = sqlBuilder.ToSql();
            var rq = _repo.GetByIdAsync<CenterQueryVm>(sql);

            return await rq;
        }

        public  IEnumerable<BuildingLookUP> GetBuilding()
        {
            var sqlBuilder = new SqlBuilder()
                .Select("B.Id as Id ,B.buildingName As BuildingName")
                .From("Rent.Building B");
            string sql = sqlBuilder.ToSql();
            var rq = _repo.GetAll<BuildingLookUP>(sql);

            return  rq;
        }
    }
  
}

//to use return must be centerQuery


//var categorizedProducts = _context.Center
//    .Join(_context.Building, p => p.buildingId, pc => pc.Id, (p, pc) => new { p, pc })
//    //.Join(_context.CenterTypes, ppc => ppc.centerTypeId, c => c.Id, (ppc, c) => new { ppc, c })
//    .Select(m => new
//     {
//         ProdId = m.ppc.p.Id, // or m.ppc.pc.ProdId
//         CatId = m.c.CatId
//         // other assignments
//     });

//var qry = from c in _context.Center
//          Join (B in _context.Building on c.buildingId equals B.Id)
//          Join( T in _context.CenterTypes on c.centerTypeId equals T.Id)
//          //  join S in _context.subsidery on c.subsideryId equals S.Id
//          .Select(s => new
//          {
//              s.c.Id,
//              s.c.centerName,
//              s.B.buildingName,
//              s.B.buildingNo,
//              s.B.address,
//              s.T.Type
//          });