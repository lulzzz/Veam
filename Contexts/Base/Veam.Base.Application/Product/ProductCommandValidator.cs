//using System;
//using System.Linq;
//using FluentValidation;

//namespace Veam.CenterRent.Application
//{
//    public class ProductCommandValidator : AbstractValidator<AddBuildingCommand>
//    {
//        private readonly IBaseDbContext _context;
//        public ProductCommandValidator(IBaseDbContext context)
//        {
//            _context = context;

//            // RuleFor(x => x.buildingId);
//            RuleFor(x => x.buildingName).MaximumLength(5);
//            RuleFor(x => x.buildingNo)
//                .Must(BeUniqueNo).WithMessage("Building no already exists");
         
//            //RuleFor(x => x.City).MaximumLength(15);
//            //RuleFor(x => x.CompanyName).MaximumLength(40).NotEmpty();
//            //RuleFor(x => x.ContactName).MaximumLength(30);
//            //RuleFor(x => x.ContactTitle).MaximumLength(30);
//            //RuleFor(x => x.Country).MaximumLength(15);
//            //RuleFor(x => x.Fax).MaximumLength(24);
//            //RuleFor(x => x.Phone).MaximumLength(24);
//            //RuleFor(x => x.PostalCode).MaximumLength(10).NotEmpty();
//            //RuleFor(x => x.Region).MaximumLength(15);
//        }

//        private bool BeUniqueNo(AddBuildingCommand cmd,string bno)
//        {
//            var valname = _context.Building.FirstOrDefault(x => x.buildingNo == bno && x.Id != cmd.buildingId);
//            if (valname != null)
//            {
//                return (false);
//            }

//            return (true);
//        }
//    }
//}
