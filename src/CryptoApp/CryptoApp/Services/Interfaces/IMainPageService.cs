using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoApp.Models;

namespace CryptoApp.Services.Interfaces
{
    public interface IMainPageService
    {
        Task<IList<Models.CryptoCoin>> GetCoins();
        Task<IList<Models.CryptoCoin>> GetCoinMarkets();
    }
}