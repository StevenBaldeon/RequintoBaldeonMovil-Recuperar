using RequintoBaldeonMovil.Services;
using RequintoBaldeonMovil.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RequintoBaldeonMovil
{
    public partial class App : Application
    {
        public static string WsUIurl = "http://192.168.1.8:5000/";

        public App()
        {
            InitializeComponent();
            ServiceWebApi.incializa(WsUIurl);

            DependencyService.Register<MockDataStore>();
            if ((App.Current.Properties.ContainsKey("USU_CODIGO") && App.Current.Properties.ContainsKey("USERNAME")))
            {
                MainPage = new NavigationPage(new MainPage()); 
            }
            else
            {

                MainPage = new NavigationPage(new LoginPage());

            }
            
            
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
