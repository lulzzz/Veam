using AutoMapper;
using Veam.EAM.Application;
using Veam.EAM.Domain;
using Veam.EAM.ViewModels;

namespace Veam.EAM
{

    public class AssetPurchaseMappings : Profile
    {
        public AssetPurchaseMappings()
        {


            #region AddCommand

            CreateMap<AssetPurchaseSaveVM, AddAssetPurchaseCommand>() 
                            ;
            #endregion

            #region Update Command
            /// map ViewModel to Dto Update command
            //CreateMap<AssetPurchaseSaveVM, UpdateAssetPurchaseCommand>() 
            //  .ReverseMap()
            //    ;

            /// Domain To Dto Update Command
            //CreateMap<AssetPurchase, UpdateAssetPurchaseCommand>() 
            //   ;
            #endregion

            #region AttachBill Command

            CreateMap<AssetPurchase, AttachBillCopyCommand>()
                 .ReverseMap();

            CreateMap<AttachBillCopyCommand, AttachBillVM>() 
                   .ReverseMap()
                ;

            #endregion

            #region Query 
            CreateMap<AssetPurchase, AssetPurchaseQueryVM>() 
                    // .ForPath(d => d.AssetType.TypeName, o => o.MapFrom(s => s.AssetType.TypeName))
                    .ReverseMap()
                ;

            CreateMap<AssetPurchase, AssetPurchaseSaveVM>() 
            ;

            #endregion
        }
    }
}