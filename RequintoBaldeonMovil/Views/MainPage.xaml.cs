using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using RequintoBaldeonMovil.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RequintoBaldeonMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
        }
        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    /* case (int)MenuItemType.Browse:
                         MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                         break;*/
                    case (int)MenuItemType.Inicio:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case (int)MenuItemType.Eventos:
                        MenuPages.Add(id, new NavigationPage(new EventosPage()));
                        break;
                    case (int)MenuItemType.Patrocinadores:
                        MenuPages.Add(id, new NavigationPage(new PatrocinadoresPage()));
                        break;
                    case (int)MenuItemType.RedesSociales:
                        MenuPages.Add(id, new NavigationPage(new RedesSocialesPage()));
                        break;
                    case (int)MenuItemType.Resena:
                        MenuPages.Add(id, new NavigationPage(new ResenaPage()));
                        break;
                        //case (int)MenuItemType.About:
                        //    MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        //    break;
                }
                var newPage = MenuPages[id];

                if (newPage != null && Detail != newPage)
                {
                    Detail = newPage;

                    if (Device.RuntimePlatform == Device.Android)
                        await Task.Delay(100);

                    IsPresented = false;
                }
                else if (id == 0)
                {
                    Detail = newPage;

                    if (Device.RuntimePlatform == Device.Android)
                        await Task.Delay(100);

                    IsPresented = false;
                }
            }
        }
    }
}