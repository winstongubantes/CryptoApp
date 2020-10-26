using System;
using Acr.UserDialogs;
using Android.App;
using Android.Runtime;

namespace CryptoApp.Droid
{
    [Application(
        Theme = "@style/MainTheme"
        )]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Xamarin.Essentials.Platform.Init(this);
            UserDialogs.Init(this);
        }
    }
}
