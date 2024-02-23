using RequintoBaldeonMovil.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using RequintoBaldeonMovil.Services;
using Acr.UserDialogs;
using RequintoBaldeonMovil.Views;

namespace RequintoBaldeonMovil.ViewModels
{
    class RegistroViewModel : BaseViewModel
    {
        private Usuario usuario;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;

        private string controlador = "/api/Registro";

        public string Nombres
        {
            get => usuario.USU_NOMBRES;
            set { usuario.USU_NOMBRES = value; OnPropertyChanged(); }
        }

        public string Apellidos
        {
            get => usuario.USU_APELLIDOS;
            set { usuario.USU_APELLIDOS = value; OnPropertyChanged(); }
        }

        public string Cedula
        {
            get => usuario.USU_CEDULA;
            set { usuario.USU_CEDULA = value; OnPropertyChanged(); }
        }

        public string Clave
        {
            get => usuario.USU_CLAVE;
            set { usuario.USU_CLAVE = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => usuario.USU_EMAIL;
            set { usuario.USU_EMAIL = value; OnPropertyChanged(); }
        }

        public string Telefono
        { 
            get => usuario.USU_TELEFONO;
            set { usuario.USU_TELEFONO = value; OnPropertyChanged(); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { this.isEnabled= value; OnPropertyChanged(); }
        }

        public ICommand ComandoRegistrar { private set; get; }
        public INavigation Navegacion { get; set; }

        public RegistroViewModel(INavigation n,Usuario u=null)
        {
            Navegacion = n;
              usuario = u ?? new Usuario() ;

            this.IsEnabledTxt = true;
            ComandoRegistrar = new Command(async () => await Registrar());

        }



        public async Task Registrar()
        {
            usuario.USU_CLAVE = Utils.Tools.R(Utils.Tools.ComputeSha256Hash(usuario.USU_CLAVE));
            bool ok = await ServiceWebApi.AgregarItem(controlador, usuario);

            if (ok)
            {
                await UserDialogs.Instance.AlertAsync("Registado Correctamente!", "Correcto", "OK");
                await Navegacion.PushAsync(new LoginPage());
            }
            else
            {
                await UserDialogs.Instance.AlertAsync("Registro incorrecto, comuniquese con el Adminstrador!", "Error", "OK");
                await Navegacion.PushAsync(new LoginPage());
            }
        }



        
    
}
}
