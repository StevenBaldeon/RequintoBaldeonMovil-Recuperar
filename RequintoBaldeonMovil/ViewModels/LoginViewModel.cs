using Acr.UserDialogs;
using RequintoBaldeonMovil.Services;
using RequintoBaldeonMovil.Views;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RequintoBaldeonMovil.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string user;
        private string userValidate;
        private string password;
        private string pwdValidate;
        private int usrUSU_CODIGO;
        object sender;
        public Command LoginCommand { get; set; }

        ///public INavigation Navigation { get; set; }


        public LoginViewModel()
        {
            //  LoginCommand = new Command(OnLoginClicked);
            usrUSU_CODIGO = 0;
            LoginCommand = new Command(async () => await Login());
            //this.sender = sender;
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        public string User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged();


            }
        }


        public string UserValidate
        {
            get { return userValidate; }
            set
            {
                userValidate = value;
                OnPropertyChanged();

            }
        }




        public string Password
        {
            get { return password; }
            set
            {
                password = value;

            }
        }

        public int UserUSU_CODIGO
        {
            get { return usrUSU_CODIGO; }
            set
            {
                usrUSU_CODIGO = value;
                OnPropertyChanged();

            }
        }





        private async Task Login()
        {

            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                
                string respuesta = await ServiceWebApi.Login("api/Logins", User,Utils.Tools.ComputeSha256Hash(Password));
                if (int.TryParse(respuesta, out this.usrUSU_CODIGO))
                {
                    App.Current.Properties["USU_CODIGO"] = usrUSU_CODIGO;
                    App.Current.Properties["USERNAME"] = User;
                    //Application.Current.MainPage.Navigation.PushModalAsync(new MainPage(), true);
                    //Application.Current.MainPage = new NavigationPage(new MainPage());
                    //  Application.Current.MainPage.Navigation.InsertPageBefore(new MainPage(), new LoginPage());
                    //((MenuPage)sender).IsPresentedChanged();

                    // MessagingCenter.Send(this, "LOGIN", "LOGUEDO: "+ UserPER_CODIGO);
                    //await App.Current.MainPage.DisplayAlert("Success", "LOGUEDO: " + UserPER_CODIGO, "Ok");
                    // App.Current.MainPage.Navigation.InsertPageBefore(new MainPage(), new LoginPage());//redirecciona pero no permite hacer back
                    //   await Application.Current.MainPage.Navigation.PopAsync(false);
                    //App.Current.MainPage.().ConfigureAwait(false);
                    //Navigation.InsertPageBefore(null, new MainPage());
                    //await Navigation.PopAsync(false);
                     App.Current.MainPage = new MainPage();
                   // Application.Current.MainPage = new NavigationPage(new MainPage());
                    //   DependencyService.Get<ISnackBar>().ShowSnackbar("CORRECTO", "#01ff01");
                    //  DependencyService.Get<ISnackBar>().ShowToast("CORRECTO");
                    //IsLogged = true;
                    // await PopupNavigation.Instance.PopAsync();
                    //DependencyService.Get<ISnackBar>().ShowToast("Inicio de Sesión Correcto.", "#006600");

                }
                else
                {
                    //   MessagingCenter.Send(this, "LOGIN", "Usuario o Password Incorrecto");
                    //await App.Current.MainPage.DisplayAlert("Autenticación Error", "Usuario o Password Incorrecto", "Aceptar");
                    // DependencyService.Get<ISnackBar>().ShowSnackbar(respuesta, "#ff2301");

                    await UserDialogs.Instance.AlertAsync(respuesta, "Error al Ingresar", "OK");
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
