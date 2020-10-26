using System;
using System.Collections.Generic;
using System.Text;
using CryptoApp.Constants;
using Refit;

namespace CryptoApp.Services
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
