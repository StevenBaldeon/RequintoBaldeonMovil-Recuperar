using RequintoBaldeonMovil.Services;
using RequintoBaldeonMovil.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RequintoBaldeonMovil
{
    public partial class App : Application
    {
        public static string WsUIurl = "http://192.168.1.20:5000/";

        public App()
        {
            InitializeComponent();
            ServiceWebApi.incializa(WsUIurl);

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
            //MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
