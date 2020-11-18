using Acr.UserDialogs;
using CryptoApp.Configurations;
using CryptoApp.Services;
using CryptoApp.Services.ApiClientServices;
using CryptoApp.Services.Interfaces;
using Prism;
using Prism.Ioc;
using CryptoApp.ViewModels;
using CryptoApp.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;

namespace CryptoApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterInstance(UserDialogs.Instance);
            containerRegistry.RegisterInstance(AutoMapperConfiguration.CreateMapper());

            containerRegistry.Register(typeof(IApiService<>), typeof(ApiService<>));
            containerRegistry.Register(typeof(IDataStoreService<>), typeof(DataStoreService<>));
            containerRegistry.Register<IMainPageService, MainPageService>();
            containerRegistry.Register<ICryptoDetailPageService, CryptoDetailPageService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CryptoDetailPage, CryptoDetailPageViewModel>();
        }
    }
}
