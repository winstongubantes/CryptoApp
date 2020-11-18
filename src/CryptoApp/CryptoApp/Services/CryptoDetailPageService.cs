using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CryptoApp.Services.ApiClientServices;
using CryptoApp.Services.Base;
using CryptoApp.Services.Interfaces;

namespace CryptoApp.Services
{
    public class CryptoDetailPageService : BaseService, ICryptoDetailPageService
    {
        private readonly IApiService<ICoinGeckoService> _coinGeckoService;
        private readonly IMapper _mapper;

        public CryptoDetailPageService(
            IApiService<ICoinGeckoService> coinGeckoService,
            IMapper mapper)
        {
            _coinGeckoService = coinGeckoService;
            _mapper = mapper;
        }

        public async Task<Models.CryptoCoinDetail> GetCoinDetails(string id)
        {
            var response =
                await InvokeWithPolicyAsync(() => _coinGeckoService.Api.GetCoinDetails(id));

            if (response.FinalException != null)
            {
                //ADD LOGGER HERE, BEFORE THROW
                throw response.FinalException;
            }

            return _mapper.Map<Models.CryptoCoinDetail>(response.Result);
        }
    }
}
