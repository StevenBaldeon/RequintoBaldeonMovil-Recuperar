using RequintoBaldeonMovil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;
using Xamarin.Forms.Xaml;

namespace RequintoBaldeonMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        MainPage RootPage { get => Xamarin.Forms.Application.Current.MainPage as MainPage; }
        MenuPage MenuPage { get => (Xamarin.Forms.Application.Current.MainPage as MasterDetailPage).Master as MenuPage; }
        public HomePage()
        {
            InitializeComponent();
        }

        private async void imgeventos_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuPage.SelectMenu((int)MenuItemType.Eventos);
            }
            catch (Exception ex)
            { 
            
            }

        }

        private void imgpatrocinadores_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuPage.SelectMenu((int)MenuItemType.Patrocinadores);
            }
            catch (Exception ex)
            {

            }
        }

        private void imgredessociales_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuPage.SelectMenu((int)MenuItemType.RedesSociales);
            }
            catch (Exception ex)
            {

            }
        }

        private void imgresena_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuPage.SelectMenu((int)MenuItemType.Resena);
            }
            catch (Exception ex)
            {

            }
        }
    }
}