﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dastone.CrossCutting.InversionOfControl.AutoMapperConfig
{
    public static class MapperConfig
    {
        public static IServiceCollection AddMapperConfiguration(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
