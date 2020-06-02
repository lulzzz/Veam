using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Veam.Application.Core.Exceptions;
using Veam.Base.Domain;

namespace Veam.Base.Application
{
    public class UpdateVendorLineCommand : VendorLineCommandDto, IRequest
    {
        public long VendorLineId { get; set; }
        /// <summary>
        /// any additional property can be here
        /// </summary>
        public class Handler : IRequestHandler<UpdateVendorLineCommand, Unit>
        {
            private readonly IBaseDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IBaseDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateVendorLineCommand rq, CancellationToken cancellationToken)
            {
                var entity = await _context.VendorLine
                     .SingleOrDefaultAsync(c => c.Id == rq.VendorLineId, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Domain.VendorLine), rq.VendorLineId);
                }
                var ContactPerson = new Person(rq.firstName, rq.lastName, rq.middleName, rq.nickName, rq.gender, rq.salutation);
                var PersonContact = new Communication(rq.mobilePhone, rq.officePhone, rq.personalEmail, rq.workEmail);
             
                entity.Update(rq.VendorLineId, rq.jobTitle, ContactPerson, PersonContact, rq.vendorId, rq.user);
                // to do ef update
                _context.VendorLine.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                //Entity updated event
                return Unit.Value;
            }
        }
    }

}

