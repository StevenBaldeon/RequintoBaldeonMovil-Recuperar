using RequintoBaldeonMovil.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RequintoBaldeonMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {

        }

        private  async void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new RegistroPage());
            } catch (Exception ex) {
                throw new Exception(ex.Message);

            }
        }

        private void btnRecuperarContrasena_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RecuperaciónCorreoPage());
        }
    }
}