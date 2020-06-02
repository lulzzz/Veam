using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Veam.Base.Application;
using Veam.Base.Domain;
using Veam.Base.ViewModels;

namespace Veam.Base
{
    public class VendorMappings : Profile
    {
        public VendorMappings()
        {
            #region AddCommand

            CreateMap<VendorSaveVM, AddVendorCommand>()
                            ;
            #endregion

            #region Update Command
            /// map ViewModel to Dto Update command
            CreateMap<VendorSaveVM, UpdateVendorCommand>()
              .ReverseMap()
                ;

            /// Domain To Dto Update Command
            CreateMap<Domain.Vendor, UpdateVendorCommand>()
               ;
            #endregion


            #region Query 
            CreateMap<Vendor, VendorQueryVM>()
           .ForMember(d => d.vendorId, o => o.MapFrom(s => s.Id))
           .ForMember(d => d.RegisterCompanyName, o => o.MapFrom(s => s.Company.RegisterCompanyName))
           .ForMember(d => d.GstNo, o => o.MapFrom(s => s.Company.GstNo))
           .ForMember(d => d.Country, o => o.MapFrom(s => s.Company.Country))
           .ForMember(d => d.OfficeContact, o => o.MapFrom(s => s.OfficeContact.officePhone))
           .ForMember(d => d.workEmail, o => o.MapFrom(s => s.OfficeContact.workEmail))
           .ForMember(d => d.BillAddress, o => o.MapFrom(s => s.BillAddress.ToString()))
            .ReverseMap()
                ;

          CreateMap<Vendor, VendorSaveVM>()
          .ForMember(d => d.vendorId, o => o.MapFrom(s => s.Id))
          .ForMember(d => d.RegisterCompanyName, o => o.MapFrom(s => s.Company.RegisterCompanyName))
          .ForMember(d => d.GstNo, o => o.MapFrom(s => s.Company.GstNo))
          .ForMember(d => d.country, o => o.MapFrom(s => s.Company.Country))
          .ForMember(d => d.line1, o => o.MapFrom(s => s.BillAddress.line1))
          .ForMember(d => d.line2, o => o.MapFrom(s => s.BillAddress.line2))
          .ForMember(d => d.city, o => o.MapFrom(s => s.BillAddress.city))
          .ForMember(d => d.state, o => o.MapFrom(s => s.BillAddress.state))
          .ForMember(d => d.zip, o => o.MapFrom(s => s.BillAddress.zip))
          .ForMember(d => d.mobilePhone, o => o.MapFrom(s => s.OfficeContact.mobilePhone))
          .ForMember(d => d.officePhone, o => o.MapFrom(s => s.OfficeContact.officePhone))
          .ForMember(d => d.personalEmail, o => o.MapFrom(s => s.OfficeContact.personalEmail))
          .ForMember(d => d.workEmail, o => o.MapFrom(s => s.OfficeContact.workEmail))
          //.ForMember(d => d.line1, o => o.MapFrom(s => s.BillAddress.line1))
          //.ForMember(d => d.line1, o => o.MapFrom(s => s.BillAddress.line1))
          //.ForMember(d => d.line1, o => o.MapFrom(s => s.BillAddress.line1))
          //.ForMember(d => d.line1, o => o.MapFrom(s => s.BillAddress.line1))
            ;
            #endregion
        }

    }

}
