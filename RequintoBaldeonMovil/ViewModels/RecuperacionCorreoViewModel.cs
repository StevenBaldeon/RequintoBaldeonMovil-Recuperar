using Acr.UserDialogs;
using RequintoBaldeonMovil.Models;
using RequintoBaldeonMovil.Services;
using RequintoBaldeonMovil.Views;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RequintoBaldeonMovil.ViewModels
{
    public class RecuperacionCorreoViewModel : BaseViewModel
    {
     
        private string email;
        object sender;
        public Command RecoverCommand { get; set; }
        public INavigation Navegacion { get; set; }
        ///public INavigation Navigation { get; set; }

        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(); }
        }
        public RecuperacionCorreoViewModel(INavigation n)
        {
            //  LoginCommand = new Command(OnLoginClicked);
            Navegacion = n;

            RecoverCommand = new Command(async () => await Recover());
            //this.sender = sender;
        }

      


        private async Task Recover()
        {

            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                
                bool respuesta = await ServiceWebApi.Recover("api/Recover",Email);
                if (respuesta)
                {
                    await UserDialogs.Instance.AlertAsync("Tu clave temporal ha sido enviada al correo", "Recuperación de Clave", "OK");
                    await Navegacion.PushAsync(new LoginPage());


                }
                else
                {
                    //   MessagingCenter.Send(this, "LOGIN", "Usuario o Password Incorrecto");
                    //await App.Current.MainPage.DisplayAlert("Autenticación Error", "Usuario o Password Incorrecto", "Aceptar");
                    // DependencyService.Get<ISnackBar>().ShowSnackbar(respuesta, "#ff2301");

                    await UserDialogs.Instance.AlertAsync("No hasido posible recuperar tu contraseña, contactate con el Administrador", "Error al Recuperar", "OK");
                    await Navegacion.PushAsync(new LoginPage());
                }
            }
            catch (Exception ex)
            {
                //  Debug.WriteLine(ex);
                if (ex.GetType() == typeof(System.TimeoutException))
                {
                    await UserDialogs.Instance.AlertAsync("Problemas de Conexión con el Servidor", "Error en Comunicaciones", "OK");
                }
                else { await UserDialogs.Instance.AlertAsync(ex.Message, "Error en Comunicaciones", "OK"); }


            }
            finally
            {
                IsBusy = false;
            }



        }
    }
}
