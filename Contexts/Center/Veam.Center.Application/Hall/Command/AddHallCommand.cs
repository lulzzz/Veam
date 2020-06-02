using MediatR;
using Sequel;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core;

namespace Veam.Centers.Application.CenterMap
{
    public class AddHallCommand : HallCommandDto, IRequest
    {
      
        /// <summary>
        /// any additional property than buildingcommand can be put here 
        /// </summary>
        public class Handler : IRequestHandler<AddHallCommand, Unit>
        {
            private readonly ICenterDbContext _context;
            private readonly IMediator _mediator;
            private readonly IBaseReadModelRepository _repo;
            public Handler(ICenterDbContext context, IMediator mediator, IBaseReadModelRepository repo)
            {
                _context = context;
                _mediator = mediator;
                _repo = repo;
            }

            public async Task<Unit> Handle(AddHallCommand rq, CancellationToken cancellationToken)
            {
                var master = _context.Center.Find(rq.centerId);//calling center
                //
                var sql = new SqlBuilder()
                  .Select("B.Id as Id ,B.buildingNo As BuildingNo")
                  .From("Rent.Building as B")
                  .Where($"B.Id={master.buildingId}")
                  .ToSql();

               // string sql = sqlBuilder.ToSql();
                var en = _repo.GetById<BuildingNoLookUP>(sql);//getting buildingNo

                string locationNo = $"{en.BuildingNO}{rq.hallNo}";//

                var entity = new Domain.Hall(rq.hallName, rq.hallNo, rq.floorNo, locationNo, rq.description,rq.centerId, rq.user);
                // to do ef save
                _context.Hall.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //put a building created event here with mediator to publish
              //  await _mediator.Publish(new HallCreated { Hallid = entity.Id }, cancellationToken);
                return Unit.Value;
            }
        }
    }

    internal class BuildingNoLookUP
    {
        public long Id { get; set; }
        public string BuildingNO { get; set; }
    }
}

