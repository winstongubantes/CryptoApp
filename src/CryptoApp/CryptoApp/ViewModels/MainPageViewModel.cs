using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CryptoApp.Models;
using CryptoApp.Services;
using CryptoApp.Views;
using Prism.Services;

namespace CryptoApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IApiService<ICoinGeckoService> _coinGeckoService;
        private readonly IUserDialogs _userDialogs;
        private readonly IDeviceService _deviceService;
        private ObservableCollection<CryptoCoin> _cryptoCoinList;
        private ObservableCollection<CryptoCoin> _cryptoCoinForSearchList;
        private IList<CryptoCoin> _cryptoCoinForSearchOriginalList;
        private string _textSearch;
        private bool _showSearchList;

        public MainPageViewModel(
            INavigationService navigationService, 
            IApiService<ICoinGeckoService> coinGeckoService, 
            IUserDialogs userDialogs, 
            IDeviceService deviceService)
            : base(navigationService)
        {
            _coinGeckoService = coinGeckoService;
            _userDialogs = userDialogs;
            _deviceService = deviceService;
            Title = "Crypto App";

            SelectedCryptoDetailCommand = new DelegateCommand<CryptoCoin>(NavigateCryptoDetail);
            SelectedCryptoCoinCommand = new DelegateCommand<CryptoCoin>(NavigateCryptoDetail);
        }

        public ObservableCollection<CryptoCoin> CryptoCoinList
        {
            get => _cryptoCoinList;
            set => SetProperty(ref _cryptoCoinList, value);
        }

        public ObservableCollection<CryptoCoin> CryptoCoinForSearchList
        {
            get => _cryptoCoinForSearchList;
            set => SetProperty(ref _cryptoCoinForSearchList, value);
        }

        public DelegateCommand<CryptoCoin> SelectedCryptoDetailCommand { get; }

        public DelegateCommand<CryptoCoin> SelectedCryptoCoinCommand { get; }

        public string TextSearch
        {
            get => _textSearch;
            set
            {
                if (SetProperty(ref _textSearch, value))
                {
                    ShowSearchList = _textSearch.Length > 0;

                    var filteredList = _cryptoCoinForSearchOriginalList
                        .Where(e => e.Id.Contains(_textSearch) ||
                                    e.Name.Contains(_textSearch) ||
                                    e.Symbol.Contains(_textSearch));

                    CryptoCoinForSearchList = new ObservableCollection<CryptoCoin>(filteredList);
                }
            }
        }

        public bool ShowSearchList
        {
            get => _showSearchList;
            set => SetProperty(ref _showSearchList, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            GetAllCoins();
        }

        private void GetAllCoins()
        {
            var loading = _userDialogs.Loading("Loading Crypto Market...");

            //WE HAVE TO ISOLATE THE THREAD TO MAKE UI RESPONSIVE
            Task.Factory.StartNew(async () =>
            {
                try
                {
                    var coinList = await _coinGeckoService.Api.GetCoins();
                    var coinMarkets = await _coinGeckoService.Api.GetCoinMarkets();

                    //CALLING BeginInvokeOnMainThread TO BRING IT BACK TO UI MAIN TRHEAD
                    _deviceService.BeginInvokeOnMainThread(() =>
                    {
                        _cryptoCoinForSearchOriginalList = coinList;
                        CryptoCoinForSearchList = new ObservableCollection<CryptoCoin>(coinList);
                        CryptoCoinList = new ObservableCollection<CryptoCoin>(coinMarkets);
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

        private void NavigateCryptoDetail(CryptoCoin obj)
        {
            var navParam = new NavigationParameters
            {
                { nameof(CryptoCoin), obj}
            };
            NavigationService.NavigateAsync(nameof(CryptoDetailPage), navParam);
        }
    }
}
