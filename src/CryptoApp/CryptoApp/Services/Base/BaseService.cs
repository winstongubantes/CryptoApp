using System;
using System.Threading.Tasks;
using Polly;

namespace CryptoApp.Services.Base
{
    public class BaseService
    {
        protected async Task<PolicyResult<T>> InvokeWithPolicyAsync<T>(Func<Task<T>> task)
        {
            return await Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(2,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .ExecuteAndCaptureAsync(task);
        }
    }
}
