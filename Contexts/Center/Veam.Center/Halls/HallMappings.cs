using AutoMapper;
using System.Linq;
using Veam.Centers.Application.CenterMap;
using Veam.Centers.Domain;
using Veam.Centers.ViewModels;

namespace Veam.Halls.Halls
{
    public class HallMappings : Profile
    {
        public HallMappings()
        {
            #region AddCommand
            CreateMap<HallSaveVM, AddHallCommand>()
                  .ForMember(d => d.hallName, o => o.MapFrom(s => s.hallName))
            .ReverseMap()
              ;
            CreateMap<AddHallCommand, Hall>()
                            // .ForMember(d => d.Id, o => o.Ignore())
                            //.ForMember(d => d.center, o => o.Ignore())
                            // .ReverseMap()
                            ;
            #endregion

            #region Update Command
            /// map ViewModel to Dto Update command
            CreateMap<HallSaveVM, UpdateHallCommand>()
              .ReverseMap()
                ;

            /// Domain To Dto Update Command
            CreateMap<Hall, UpdateHallCommand>()
               ;
            #endregion


            #region Query 
            ///mAp from domain to QueryVM No need As mapped from sql in Read Repository
            CreateMap<Hall, HallSaveVM>()
          .ForMember(d => d.HallId, o => o.MapFrom(s => s.Id))
            ;




            CreateMap<Hall, HallQueryVM>() 
            .ForMember(d => d.HallId, o => o.MapFrom(s => s.Id))
         .ForMember(d => d.CenterName, o => o.MapFrom(s => s.center.centerName))
           // .IncludeMembers(s => s.center)
            //.ReverseMap()
            ;
            //CreateMap<Center, HallQueryVM>(MemberList.Destination)
            //     .ForMember(d => d.CenterName, o => o.MapFrom(s => s.centerName));
            #endregion
        }

    }
}
