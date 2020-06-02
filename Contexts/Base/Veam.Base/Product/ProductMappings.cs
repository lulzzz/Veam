using AutoMapper;
using Veam.Base.Application;
using Veam.Base.Domain;
using Veam.Base.ViewModels;

namespace Veam.Base
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            #region AddCommand

            CreateMap<ProductSaveVM, AddProductCommand>()
                 //.ForMember(d => d, o => o.MapFrom(s => s.Id))
                            ;
            #endregion

            #region Update Command
            /// map ViewModel to Dto Update command
            CreateMap<ProductSaveVM, UpdateProductCommand>()
              .ReverseMap()
                ;

            /// Domain To Dto Update Command
            CreateMap<Domain.Product, UpdateProductCommand>()
               ;
            #endregion


            #region Query 
            CreateMap<Product, ProductQueryVM>()
                  .ForMember(d => d.productId, o => o.MapFrom(s => s.Id))
                   .ForMember(d => d.productCategory, o => o.MapFrom(s => s.productCategory.Category))
                   // .ForPath(d => d.productType.TypeName, o => o.MapFrom(s => s.productType.TypeName))
                  //  .ReverseMap()
                ;
            CreateMap<Domain.ProductType, ProductTypeVM>();

            CreateMap<Product, ProductSaveVM>()
          .ForMember(d => d.productId, o => o.MapFrom(s => s.Id))
            ;
            #endregion
        }

    }

}

