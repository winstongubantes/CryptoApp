using CryptoApp.Constants;
using Refit;

namespace CryptoApp.Services.ApiClientServices
{
    public class ApiService<T> : IApiService<T>
    {
        public ApiService()
        {
            Api = RestService.For<T>(AppConstant.WebApiBaseUrl);
        }

        public T Api { get; }
    }
}
