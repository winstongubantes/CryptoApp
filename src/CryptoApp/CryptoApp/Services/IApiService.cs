using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoApp.Services
{
    public interface IApiService<T>
    {
        T Api { get; }
    }
}
