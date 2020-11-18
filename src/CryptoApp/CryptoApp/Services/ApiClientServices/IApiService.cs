namespace CryptoApp.Services.ApiClientServices
{
    public interface IApiService<T>
    {
        T Api { get; }
    }
}
