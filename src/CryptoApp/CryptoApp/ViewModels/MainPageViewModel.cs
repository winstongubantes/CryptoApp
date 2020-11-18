using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CryptoApp.Services.ApiClientServices;
using CryptoApp.Services.Interfaces;
using CryptoApp.ViewModels.Base;
using CryptoApp.Views;
using Prism.Services;

namespace CryptoApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        private readonly IDeviceService _deviceService;
        private readonly IMainPageService _mainPageService;

        private ObservableCollection<Models.CryptoCoin> _cryptoCoinList;
        private ObservableCollection<Models.CryptoCoin> _cryptoCoinForSearchList;
        private IList<Models.CryptoCoin> _cryptoCoinForSearchOriginalList;
        private string _textSearch;
        private bool _showSearchList;

        public MainPageViewModel(
            INavigationService navigationService,
            IUserDialogs userDialogs, 
            IDeviceService deviceService, 
            IMainPageService mainPageService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            _deviceService = deviceService;
            _mainPageService = mainPageService;
            Title = "Crypto App";

            SelectedCryptoDetailCommand = new DelegateCommand<Models.CryptoCoin>(NavigateCryptoDetail);
            SelectedCryptoCoinCommand = new DelegateCommand<Models.CryptoCoin>(NavigateCryptoDetail);
        }

        public ObservableCollection<Models.CryptoCoin> CryptoCoinList
        {
            get => _cryptoCoinList;
            set => SetProperty(ref _cryptoCoinList, value);
        }

        public ObservableCollection<Models.CryptoCoin> CryptoCoinForSearchList
        {
            get => _cryptoCoinForSearchList;
            set => SetProperty(ref _cryptoCoinForSearchList, value);
        }

        public DelegateCommand<Models.CryptoCoin> SelectedCryptoDetailCommand { get; }

        public DelegateCommand<Models.CryptoCoin> SelectedCryptoCoinCommand { get; }

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

                    CryptoCoinForSearchList = new ObservableCollection<Models.CryptoCoin>(filteredList);
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
                    var coinList = await _mainPageService.GetCoins();
                    var coinMarkets = await _mainPageService.GetCoinMarkets();

                    //CALLING BeginInvokeOnMainThread TO BRING IT BACK TO UI MAIN TRHEAD
                    _deviceService.BeginInvokeOnMainThread(() =>
                    {
                        _cryptoCoinForSearchOriginalList = coinList;
                        CryptoCoinForSearchList = new ObservableCollection<Models.CryptoCoin>(coinList);
                        CryptoCoinList = new ObservableCollection<Models.CryptoCoin>(coinMarkets);
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

        private void NavigateCryptoDetail(Models.CryptoCoin obj)
        {
            var navParam = new NavigationParameters
            {
                { nameof(Models.CryptoCoin), obj}
            };
            _navigationService.NavigateAsync(nameof(CryptoDetailPage), navParam);
        }
    }
}
