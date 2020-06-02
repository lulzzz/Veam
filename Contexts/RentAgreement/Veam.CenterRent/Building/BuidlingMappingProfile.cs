using AutoMapper;
using Veam.CenterRent.Application;
using Veam.CenterRent.Domain;
using Veam.Domain.Core.ValueObjects;

namespace Veam.CenterRent.ViewModels
{
    public class BuidlingMappingProfile : Profile

    {
        public BuidlingMappingProfile()
        {
            #region AddCommand

            CreateMap<BuildingSaveVM, AddBuildingCommand>()
            .ForMember(d => d.Line1, o => o.MapFrom(m => m.address.Line1))
            .ForMember(d => d.Line2, o => o.MapFrom(s => s.address.Line2))
            .ForMember(d => d.City, o => o.MapFrom(s => s.address.City))
            .ForMember(d => d.State, o => o.MapFrom(s => s.address.State))
            .ForMember(d => d.Zip, o => o.MapFrom(s => s.address.Zip))
                            ;
            #endregion

            #region Update Command
            /// map ViewModel to Dto Update command
            CreateMap<BuildingSaveVM, UpdateBuildingCommand>()
              .ForMember(d => d.Line1, o => o.MapFrom(m => m.address.Line1))
              .ForMember(d => d.Line2, o => o.MapFrom(s => s.address.Line2))
              .ForMember(d => d.City, o => o.MapFrom(s => s.address.City))
              .ForMember(d => d.State, o => o.MapFrom(s => s.address.State))
              .ForMember(d => d.Zip, o => o.MapFrom(s => s.address.Zip))
              .ReverseMap()
                ;
            /// map ViewModel to Dto Update command
            CreateMap<AddressVM,Address>()
              .ForMember(d => d.line1, o => o.MapFrom(m => m. Line1))
              .ForMember(d => d.line2, o => o.MapFrom(s => s.Line2))
              .ForMember(d => d.city, o => o.MapFrom(s => s.City))
              .ForMember(d => d.state, o => o.MapFrom(s => s.State))
              .ForMember(d => d.zip, o => o.MapFrom(s => s.Zip))
              .ReverseMap()
                ;
            /// Domain To Dto Update Command
            CreateMap<Building, UpdateBuildingCommand>()
             .ForMember(d => d.buildingId, o => o.MapFrom(m => m.Id))
             .ForMember(d => d.Line1, o => o.MapFrom(m => m.address.line1))
             .ForMember(d => d.Line2, o => o.MapFrom(s => s.address.line2))
             .ForMember(d => d.City, o => o.MapFrom(s => s.address.city))
             .ForMember(d => d.State, o => o.MapFrom(s => s.address.state))
             .ForMember(d => d.Zip, o => o.MapFrom(s => s.address.zip))
               ;
            #endregion

            #region Details and List
            CreateMap<Building, BuildingQueryVM>()
              .ForMember(d => d.buildingId, o => o.MapFrom(s => s.Id))
              .ForMember(d => d.Addressfull, o => o.MapFrom(m => m.address.ToString()))
              .ForMember(d => d.buildingNo, o => o.MapFrom(s => s.buildingNo))
              .ForMember(d => d.buildingName, o => o.MapFrom(s => s.buildingName))
                ;
            //for edit Query
            CreateMap<Building, BuildingSaveVM>()
              .ForMember(d => d.buildingId, o => o.MapFrom(s => s.Id))
              .ForMember(d => d.Addressfull, o => o.Ignore())
              .ForMember(d => d.buildingNo, o => o.MapFrom(s => s.buildingNo))
              .ForMember(d => d.buildingName, o => o.MapFrom(s => s.buildingName))
               ;
            #endregion
        }
    }
}

