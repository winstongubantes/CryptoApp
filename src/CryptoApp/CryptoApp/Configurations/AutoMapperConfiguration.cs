using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace CryptoApp.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Models.Dtos.CryptoCoin, Models.CryptoCoin>();
                cfg.CreateMap<Models.Dtos.CryptoCoinDetail, Models.CryptoCoinDetail>()
                    .ForMember(e=> e.LargeImage, ex => ex.MapFrom(e=> e.Image.Large))
                    .ForMember(e => e.CurrentPrice, ex => ex.MapFrom(e => e.MarketData.CurrentPrice.Usd))
                    .ForMember(e => e.Description, ex => ex.MapFrom(e => e.Description.En));
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
