using RequintoBaldeonMovil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RequintoBaldeonMovil.ViewModels;
 

namespace RequintoBaldeonMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            this.IsPresentedChange();
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Inicio, Title="Inicio", icon="Facebook.png"},
                 new HomeMenuItem {Id = MenuItemType.Eventos, Title="Eventos", icon="Eventos_Menu.png"},
                new HomeMenuItem {Id = MenuItemType.Patrocinadores, Title="Patrocinadores", icon="Patrocinadores_Menu.png"},
                new HomeMenuItem {Id = MenuItemType.RedesSociales, Title="Redes Sociales", icon="RedesSociales_Menu.png"},
                new HomeMenuItem {Id = MenuItemType.Resena, Title="Reseña", icon="Resena_Menu.png"}
            };

            ListViewMenu.ItemsSource=menuItems;
            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                if ((App.Current.Properties.ContainsKey("PER_CODIGO") && App.Current.Properties.ContainsKey("USERNAME")) || id == 0 || id == 1 || id == 2 || id == 3)
                {
                    await RootPage.NavigateFromMenu(id);
                    this.IsPresentedChange();

                }
            };
        }
        public async void SelectMenu(int id)
        {
            ListViewMenu.SelectedItem = menuItems[id];
        }
        private void btnLogout_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {

        }
        public void IsPresentedChange()
        {
           /* if (App.Current.Properties.ContainsKey("PER_CODIGO"))
            {
                lblUser.Text = App.Current.Properties["USERNAME"].ToString();
                btnLogout.IsVisible = true;
                btnLogin.IsVisible = false;
            }
            else
            {
                lblUser.Text = "";
                btnLogout.IsVisible = false;
                btnLogin.IsVisible = true;
            }*/
        }
    }
}