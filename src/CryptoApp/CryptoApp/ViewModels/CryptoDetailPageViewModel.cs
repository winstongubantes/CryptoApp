using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Acr.UserDialogs;
using CryptoApp.Models;
using CryptoApp.Services;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CryptoApp.ViewModels
{
    public class CryptoDetailPageViewModel : ViewModelBase
    {
        private readonly IApiService<ICoinGeckoService> _coinGeckoService;
        private readonly IUserDialogs _userDialogs;
        private readonly IDeviceService _deviceService;
        private CryptoCoin _selectedCryptoCoin;
        private CryptoCoinDetail _cryptoCoinDetail;

        public CryptoDetailPageViewModel(
            INavigationService navigationService, 
            IApiService<ICoinGeckoService> coinGeckoService, 
            IUserDialogs userDialogs, 
            IDeviceService deviceService)
            : base(navigationService)
        {
            _coinGeckoService = coinGeckoService;
            _userDialogs = userDialogs;
            _deviceService = deviceService;
            Title = "Crypto Detail Page";


        }

        public CryptoCoinDetail CryptoCoinDetail 
        {             
            get => _cryptoCoinDetail;
            set => SetProperty(ref _cryptoCoinDetail, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _selectedCryptoCoin = parameters.GetValue<CryptoCoin>(nameof(CryptoCoin));

            GetCryptoCoinDetails();
        }

        private void GetCryptoCoinDetails()
        {
            var loading = _userDialogs.Loading("Loading Crypto Details...");

            //WE HAVE TO ISOLATE THE THREAD TO MAKE UI RESPONSIVE
            Task.Factory.StartNew(async () =>
            {
                try
                {
                    var coinDetail = await _coinGeckoService.Api.GetCoinDetails(_selectedCryptoCoin.Id);
                    
                    //CALLING BeginInvokeOnMainThread TO BRING IT BACK TO UI MAIN TRHEAD
                    _deviceService.BeginInvokeOnMainThread(() =>
                    {
                        CryptoCoinDetail = coinDetail;
                        loading.Hide();
                    });
                }
                catch (Exception ex)
                {
                    _deviceService.BeginInvokeOnMainThread(async () =>
                    {
                        Debug.WriteLine(ex.Message);
                        loading.Hide();
                        await _userDialogs.AlertAsync("Something went wrong!", "Error");
                    });
                }
            });
        }
    }
}
