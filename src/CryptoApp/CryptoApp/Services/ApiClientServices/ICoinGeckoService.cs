using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoApp.Models.Dtos;
using Refit;

namespace CryptoApp.Services.ApiClientServices
{
    [Headers("Content-Type: application/json")]
    public interface ICoinGeckoService
    {
        [Get("/coins/list")]
        Task<IList<CryptoCoin>> GetCoins();

        [Get("/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false")]
        Task<IList<CryptoCoin>> GetCoinMarkets();

        [Get("/coins/{id}?tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=false")]
        Task<CryptoCoinDetail> GetCoinDetails([AliasAs("id")] string id);
    }
}