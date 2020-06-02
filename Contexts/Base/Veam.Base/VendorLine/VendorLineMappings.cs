using AutoMapper;
using Veam.Base.Application;
using Veam.Base.Domain;
using Veam.Base.ViewModels;

namespace Veam.Base
{
    public class VendorLineMappings : Profile
    {
        public VendorLineMappings()
        {
            #region AddCommand

            CreateMap<VendorLineSaveVM, AddVendorLineCommand>()
                            ;
            #endregion

            #region Update Command
            /// map ViewModel to Dto Update command
            CreateMap<VendorLineSaveVM, UpdateVendorLineCommand>()
              .ReverseMap()
                ;

            /// Domain To Dto Update Command
            CreateMap<Domain.VendorLine, UpdateVendorLineCommand>()
               ;
            #endregion


            #region Query 
            CreateMap<VendorLine, VendorLineQueryVM>()
                  .ForMember(d => d.vendorLineId, o => o.MapFrom(s => s.Id))
                    .ForPath(d => d.ContactFullName, o => o.MapFrom(s => s.person.ToString()))
                     .ForPath(d => d.mobilePhone, o => o.MapFrom(s => s.personContact.mobilePhone))
                    .ReverseMap()
                ;

            CreateMap<VendorLine, VendorLineSaveVM>()
          .ForMember(d => d.vendorLineId, o => o.MapFrom(s => s.Id))
          .ForMember(d => d.jobTitle, o => o.MapFrom(s => s.jobTitle))
          .ForMember(d => d.firstName, o => o.MapFrom(s => s.person.firstName))
          .ForMember(d => d.middleName, o => o.MapFrom(s => s.person.middleName))
          .ForMember(d => d.lastName, o => o.MapFrom(s => s.person.lastName))
          .ForMember(d => d.nickName, o => o.MapFrom(s => s.person.nickName))
          .ForMember(d => d.gender, o => o.MapFrom(s => s.person.gender))
          .ForMember(d => d.salutation, o => o.MapFrom(s => s.person.salutation))
          .ForMember(d => d.mobilePhone, o => o.MapFrom(s => s.personContact.mobilePhone))
          .ForMember(d => d.officePhone, o => o.MapFrom(s => s.personContact.officePhone))
          .ForMember(d => d.personalEmail, o => o.MapFrom(s => s.personContact.personalEmail))
          .ForMember(d => d.workEmail, o => o.MapFrom(s => s.personContact.workEmail))
          .ForMember(d => d.vendorId, o => o.MapFrom(s => s.vendorId))
          //.ForMember(d => d.vendorLineId, o => o.MapFrom(s => s.Id))
            ;
            #endregion
        }

    }

}
