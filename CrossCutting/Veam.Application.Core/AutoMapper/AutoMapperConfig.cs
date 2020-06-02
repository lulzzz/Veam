using AutoMapper;

namespace Veam.Application.Core
{

    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {       
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
              
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
