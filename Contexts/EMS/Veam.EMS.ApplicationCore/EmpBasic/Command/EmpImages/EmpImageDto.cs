using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Veam.EMS.Domain;
using Veam.File;

namespace Veam.EMS.Application.EmpBasic.Command.EmpImages
{
    public class EmpImageDto
    {
        public IFormFile img { get; set; }

        public bool IsLocked { get; set; }
        public string Tagname { get; set; }
        public string ImageUrl { get; set; }
        public long EmployeeId { get; set; }
    }

    //event
    public class EmpImageUploaded
    {
        public long Id { get; set; }
    }

    public class UploadEmpImageCommand : EmpImageDto, IRequest
    {
        public long id { get; set; }
        public string user { get; set; }

        public class Hanlder : IRequestHandler<UploadEmpImageCommand, Unit>
        {
            private readonly IEmployeeContext _context;
            private readonly IMediator _mediator;
            private readonly IExtFileUpload _fs;
            public Hanlder(IEmployeeContext context, IMediator mediator, IExtFileUpload fs)
            {
                _context = context;
                _mediator = mediator;
                _fs = fs;
            }

            public async Task<Unit> Handle(UploadEmpImageCommand rq, CancellationToken cancellationToken)
            {
                var file = await _fs.UploadFile(rq.img, rq.EmployeeId.ToString());
                var tagname = rq.Tagname ?? file.tagName;
                var filename = file.uniqueName;
                var filesize = file.fileSize;
                // todo: define default tagname and store in physical location and save path here

                var entity = new EmployeeImage(rq.EmployeeId,rq.id,rq.user,filename,tagname,rq.ImageUrl,filesize,rq.IsLocked);
                if (rq.id == 0) _context.EmployeeImage.Add(entity);
                else _context.EmployeeImage.Update(entity);

               await _context.SaveChangesAsync(cancellationToken);
                // Event
               await _mediator.Publish(new EmpImageUploaded { Id=entity.Id},cancellationToken);
                return Unit.Value;
            }
        }
    }

   
}
