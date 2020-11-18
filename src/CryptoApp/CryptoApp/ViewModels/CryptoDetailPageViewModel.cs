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
using CryptoApp.Models.Dtos;
using CryptoApp.Services.ApiClientServices;
using CryptoApp.Services.Interfaces;
using CryptoApp.ViewModels.Base;

namespace CryptoApp.ViewModels
{
    public class CryptoDetailPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly IDeviceService _deviceService;
        private readonly ICryptoDetailPageService _cryptoDetailPageService;

        private Models.CryptoCoin _selectedCryptoCoin;
        private Models.CryptoCoinDetail _cryptoCoinDetail;

        public CryptoDetailPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs, 
            IDeviceService deviceService, 
            ICryptoDetailPageService cryptoDetailPageService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _deviceService = deviceService;
            _cryptoDetailPageService = cryptoDetailPageService;
            Title = "Crypto Detail Page";


        }

        public Models.CryptoCoinDetail CryptoCoinDetail 
        {             
            get => _cryptoCoinDetail;
            set => SetProperty(ref _cryptoCoinDetail, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _selectedCryptoCoin = parameters.GetValue<Models.CryptoCoin>(nameof(Models.CryptoCoin));
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
                    var coinDetail = await _cryptoDetailPageService.GetCoinDetails(_selectedCryptoCoin.Id);
                    
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
