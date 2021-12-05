using AutoMapper;
using read_feed.api.Entities;
using read_feed.core.ApiDto;

namespace read_feed.api.Infra
{
    public static class CustomMappers
    {
        public static MapperConfiguration AddCustomMappers(this IServiceCollection services)
        {
            var config = CreateMapperConfig();
            services.AddSingleton<IMapper>(config.CreateMapper());
            return config;
        }

        private static MapperConfiguration CreateMapperConfig()
            => new (cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });
    }
}
