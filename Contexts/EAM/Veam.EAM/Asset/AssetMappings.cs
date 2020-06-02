using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Veam.EAM.Application;
using Veam.EAM.Domain;
using Veam.EAM.ViewModels;

namespace Veam.EAM
{
    public class AssetMappings : Profile
    {
        public AssetMappings()
        {
            //#region AddCommand

            //CreateMap<AssetSaveVM, AddNewAssetCommand>()
            // .ForMember(d => d.modalnumber, o => o.MapFrom(s => s.modelNo))
            //                ;
            //#endregion

            #region Update Command
            /// map ViewModel to Dto Update command
            CreateMap<AssetSaveVM, UpdateAssetCommand>()
                .ForPath(d => d.modalnumber, o => o.MapFrom(s => s.modelNo))
              .ReverseMap()
                ;

            /// Domain To Dto Update Command
            CreateMap<Asset, UpdateAssetCommand>()
               ;
            #endregion

            #region UpdateWarranty Command

            CreateMap<Asset, AssetWarrantyVM>()
               .ForMember(d => d.assetId, o => o.MapFrom(s => s.Id))
                 .ForPath(d => d.warrantyBy, o => o.MapFrom(s => s.warranty.warrantyBy))
                 .ForPath(d => d.StartDate, o => o.MapFrom(s => s.warranty.StartDate))
                 .ForPath(d => d.EndDate, o => o.MapFrom(s => s.warranty.EndDate))
                 .ForPath(d => d.periodinMonths, o => o.MapFrom(s => s.warranty.periodinMonths))
                 .ForPath(d => d.notes, o => o.MapFrom(s => s.warranty.notes)) 
                 .ReverseMap();

            CreateMap<UpdateAssetWarrantyInfoCommand, AssetWarrantyVM>()
                 .ForMember(d => d.assetId, o => o.MapFrom(s => s.AssetId))
                   .ReverseMap()
                ;
        
            #endregion

            #region Query 
            CreateMap<Asset, AssetQueryVM>()
                  .ForMember(d => d.assetId, o => o.MapFrom(s => s.Id))
                    .ForPath(d => d.modelNo, o => o.MapFrom(s => s.assetModel.number))
                    .ForPath(d => d.status, o => o.MapFrom(s => s.assetstatus.status))
                    // .ForPath(d => d.AssetType.TypeName, o => o.MapFrom(s => s.AssetType.TypeName))
                    .ReverseMap()
                ;
            CreateMap<Asset, AssetQr>()
                .ForMember(d => d.assetId, o => o.MapFrom(s => s.Id)) 
                  .ReverseMap()
              ;

            CreateMap<Asset, AssetSaveVM>()
          .ForMember(d => d.assetId, o => o.MapFrom(s => s.Id))
              .ForPath(d => d.modelNo, o => o.MapFrom(s => s.assetModel.number))
                 .ForPath(d => d.modalname, o => o.MapFrom(s => s.assetModel.name))
                    .ForPath(d => d.brand, o => o.MapFrom(s => s.assetModel.brand))
                       .ForPath(d => d.product, o => o.MapFrom(s => s.assetModel.product)) 
            ;

            #endregion
        }

    }

}
