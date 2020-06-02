using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Veam.EMS.Domain;
using Veam.File;
using Veam.FileStorage.Abstractions;

namespace Veam.EMS.Application.EmpBasic.Command.EmpDocuments
{
    public class UploadDocumentCommand: EmpDocumrntDto,IRequest
    {
        public long DocId { get; set; }
        public string user { get; set; }

        public class Handler : IRequestHandler<UploadDocumentCommand, Unit>
        {
            private readonly IEmployeeContext _context;
            private readonly IExtFileUpload _fs;
            private readonly IMediator _mediator;
           
            public Handler(IEmployeeContext context, IMediator mediator, IExtFileUpload fs)
            {
                _context = context;
                _mediator = mediator;
                _fs = fs;
            }

            public async Task<Unit> Handle(UploadDocumentCommand rq, CancellationToken cancellationToken)
            {
                var file = await _fs.UploadFile(rq.file,rq.EmployeeId.ToString());
                var tagname = rq.Tagname ?? file.tagName;
                var filename = file.uniqueName;
                var filesize = file.fileSize;
                var entity = new EmployeeDocuments(0, rq.EmployeeId, rq.user, filename, tagname, rq.FileUrl, filesize, rq.IsLocked); ;
              _context.EmployeeDocument.Add(entity);
              await  _context.SaveChangesAsync(cancellationToken);

                //Event
                await _mediator.Publish(new EmpDocumentsUploaded { Id=entity.Id},cancellationToken);
                return Unit.Value;
            }
        }
    }

   
}
