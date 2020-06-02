using AutoMapper;

namespace Veam.Application.Core
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
        }
    }
}


///from Christ 3D
//CreateMap<StudentViewModel, Student>()
// .ForPath(d => d.Address.Province, o => o.MapFrom(s => s.Province))
// .ForPath(d => d.Address.City, o => o.MapFrom(s => s.City))
// .ForPath(d => d.Address.County, o => o.MapFrom(s => s.County))
// .ForPath(d => d.Address.Street, o => o.MapFrom(s => s.Street))
// ;
//CreateMap<StudentViewModel, UpdateStudentCommand>()
//    .ConstructUsing(c => new UpdateStudentCommand(c.Id, c.Name, c.Email, c.BirthDate, c.Phone, c.Province, c.City,
//c.County, c.Street));


//CreateMap<OrderViewModel, Order>();

//CreateMap<OrderViewModel, RegisterOrderCommand>();