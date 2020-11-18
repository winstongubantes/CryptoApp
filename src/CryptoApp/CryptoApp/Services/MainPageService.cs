using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CryptoApp.Models;
using CryptoApp.Services.ApiClientServices;
using CryptoApp.Services.Base;
using CryptoApp.Services.Interfaces;

namespace CryptoApp.Services
{
    public class MainPageService : BaseService, IMainPageService
    {
        private readonly IApiService<ICoinGeckoService> _coinGeckoService;
        private readonly IMapper _mapper;

        public MainPageService(
            IApiService<ICoinGeckoService> coinGeckoService,
            IMapper mapper)
        {
            _coinGeckoService = coinGeckoService;
            _mapper = mapper;
        }

        public async Task<IList<Models.CryptoCoin>> GetCoins()
        {
            var response =
                await InvokeWithPolicyAsync(() => _coinGeckoService.Api.GetCoins());

            if (response.FinalException != null)
            {
                //ADD LOGGER HERE, BEFORE THROW
                throw response.FinalException;
            }

            return _mapper.Map<IList<Models.CryptoCoin>>(response.Result);
        }


        public async Task<IList<Models.CryptoCoin>> GetCoinMarkets()
        {
            var response =
                await InvokeWithPolicyAsync(() => _coinGeckoService.Api.GetCoinMarkets());

            if (response.FinalException != null)
            {
                //ADD LOGGER HERE, BEFORE THROW
                throw response.FinalException;
            }

            return _mapper.Map<IList<Models.CryptoCoin>>(response.Result);
        }
    }
}
