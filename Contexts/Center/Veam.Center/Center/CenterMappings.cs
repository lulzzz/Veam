using AutoMapper;
using Veam.Centers.Application.CenterMap;

namespace Veam.Centers.ViewModels
{
    public class CenterMappings : Profile
    {
        public CenterMappings()
        {
            #region AddCommand

            CreateMap<CenterSaveVm, AddCenterCommand>()
                            ;
            #endregion

            #region Update Command
            /// map ViewModel to Dto Update command
            CreateMap<CenterSaveVm, UpdateCenterCommand>()
              .ReverseMap()
                ;

            /// Domain To Dto Update Command
            CreateMap<Domain.Center, UpdateCenterCommand>()
               ;
            #endregion


            #region Query 
            ///mAp from domain to QueryVM No need As mapped from sql in Read Repository
            CreateMap<Domain.Center, CenterSaveVm>()
          .ForMember(d => d.CenterId, o => o.MapFrom(s => s.Id))
          .ForMember(d => d.buildingId, o => o.MapFrom(s => s.buildingId))
          .ForMember(d => d.isHO, o => o.MapFrom(s => s.isHQ))
            ;

            //directly mapped from Sql
        //    CreateMap<Domain.Center, CenterQueryVm>()
        //.ForMember(d => d.CenterId, o => o.MapFrom(s => s.Id))
        ////.ForMember(d => d.buildingName, o => o.MapFrom(s => s.))
        //.ForMember(d => d.isHO, o => o.MapFrom(s => s.isHQ))
        //  ;
            #endregion
        }

    }
}
