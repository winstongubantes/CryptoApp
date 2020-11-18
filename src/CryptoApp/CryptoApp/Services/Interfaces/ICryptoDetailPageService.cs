using System.Threading.Tasks;

namespace CryptoApp.Services.Interfaces
{
    public interface ICryptoDetailPageService
    {
        Task<Models.CryptoCoinDetail> GetCoinDetails(string id);
    }
}