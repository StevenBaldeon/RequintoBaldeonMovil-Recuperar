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
using Xamarin.CommunityToolkit.Converters;
using System.Security.Cryptography.X509Certificates;

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

        public bool isValidNombres;

        public bool IsValidNombres
        {
            get { return this.isValidNombres; }
            set { this.isValidNombres = value; OnPropertyChanged(); }
        }

        public string Apellidos
        {
            get => usuario.USU_APELLIDOS;
            set { usuario.USU_APELLIDOS = value; OnPropertyChanged(); }
        }
        public bool isValidApellidos;

        public bool IsValidApellidos
        {
            get { return this.isValidApellidos; }
            set { this.isValidApellidos = value; OnPropertyChanged(); }
        }

        public string Cedula
        {
            get => usuario.USU_CEDULA;
            set { usuario.USU_CEDULA = value; OnPropertyChanged(); }
        }

        public bool isValidCedula;

        public bool IsValidCedula
        {
            get { return this.isValidCedula; }
            set { this.isValidCedula = value; OnPropertyChanged(); }
        }

        private string validCedulaMsg;
        public string ValidCedulaMsg
        {
            get => validCedulaMsg;
            set { validCedulaMsg = value; OnPropertyChanged(); }
        }

        public string Clave
        {
            get => usuario.USU_CLAVE;
            set { usuario.USU_CLAVE = value; OnPropertyChanged(); }
        }
       

        public bool isValidClave;

        public bool IsValidClave
        {
            get { return this.isValidClave; }
            set { this.isValidClave= value; OnPropertyChanged(); }
        }


        public string Email
        {
            get => usuario.USU_EMAIL;
            set { usuario.USU_EMAIL = value; OnPropertyChanged(); }
        }
        private string validEmailMsg;
        public string ValidEmailMsg
        {
            get => validEmailMsg;
            set { validEmailMsg = value; OnPropertyChanged(); }
        }

        public bool isValidEmail;

        public bool IsValidEmail
        {
            get { return this.isValidEmail; }
            set { this.isValidEmail = value; OnPropertyChanged(); }
        }
        public string Telefono
        { 
            get => usuario.USU_TELEFONO;
            set { usuario.USU_TELEFONO = value; OnPropertyChanged(); }
        }

        private string claveRepite;
        public string ClaveRepite
        {
            get => claveRepite;
            set { claveRepite = value; OnPropertyChanged(); }
        }
        public bool isValidClaveRep;

        public bool IsValidClaveRep
        {
            get { return this.isValidClaveRep; }
            set { this.isValidClaveRep = value; OnPropertyChanged(); }
        }

        public bool isValidTelefono;

        public bool IsValidTelefono
        {
            get { return this.isValidTelefono; }
            set { this.isValidTelefono = value; OnPropertyChanged(); }
        }


        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { this.isEnabled= value; OnPropertyChanged(); }
        }

        public ICommand ComandoRegistrar { private set; get; }
        public INavigation Navegacion { get; set; }
        public ICommand EntryUnfocused { get; protected set; }
       // public Command<object> EntryUnfocused { get; set; }

        public RegistroViewModel(INavigation n,Usuario u=null)
        {
            Navegacion = n;
              usuario = u ?? new Usuario() ;

            this.IsEnabledTxt = true;
            this.isValidCedula = false;
            ComandoRegistrar = new Command(async () => await Registrar());
            EntryUnfocused = new Command(CompletedCommandExecutedAsync);

        }


        private async void ValidFiled(object obj)
        {

            if (obj.ToString() == "nombres")
            {
                this.IsValidNombres = String.IsNullOrEmpty(this.Nombres) ? true : false;

            }
            if (obj.ToString() == "apellidos")
            {
                this.IsValidApellidos = String.IsNullOrEmpty(this.Apellidos) ? true : false;

            }
            if (obj.ToString() == "cedula")
            {
               
                this.IsValidCedula = String.IsNullOrEmpty(this.Cedula) ? true : false;
                decimal USU_CODIGO = String.IsNullOrEmpty(this.Cedula)?-1:await ServiceWebApi.ValidarEmailCedula("api/Validar", "C", this.Cedula);
                this.IsValidCedula = (USU_CODIGO > 0 || USU_CODIGO == -1) ? true : false;
                this.ValidCedulaMsg = String.IsNullOrEmpty(this.Cedula) ? "Cédula es Obligatorio" : USU_CODIGO > 0 ? "Cédula ya registrada, consulte con el administrador" : USU_CODIGO == -1 ? "Cédula Invalida" : "";


            }
            if (obj.ToString() == "email")
            {
                this.IsValidEmail = String.IsNullOrEmpty(this.Email) ? true : false;
                this.IsValidEmail = (String.IsNullOrEmpty(this.Email) ? -1 :await ServiceWebApi.ValidarEmailCedula("api/Validar", "E", this.Email)) != 0 ? true : false;
                this.ValidEmailMsg = String.IsNullOrEmpty(this.Email) ? "Email es Obligatorio" : "Email ya registrado, consulte con el administrador";

            }
            if (obj.ToString() == "clave")
            {
                this.IsValidClave = String.IsNullOrEmpty(this.Clave) ? true : false;

            }
            if (obj.ToString() == "claveRep")
            {
                this.IsValidClaveRep = (String.IsNullOrEmpty(this.ClaveRepite) || !(this.Clave.Equals(this.ClaveRepite))) ? true : false;

            }
            if (obj.ToString() == "telefono")
            {
                this.IsValidTelefono = String.IsNullOrEmpty(this.Telefono) ? true : false;

            }

        }


        private async Task<bool> ValidFields()
        {
            
                this.IsValidNombres = String.IsNullOrEmpty(this.Nombres) ? true : false;

           
                this.IsValidApellidos = String.IsNullOrEmpty(this.Apellidos) ? true : false;

            
                this.IsValidCedula = String.IsNullOrEmpty(this.Cedula) ? true : false;
            decimal USU_CODIGO = String.IsNullOrEmpty(this.Cedula) ? -1 : await ServiceWebApi.ValidarEmailCedula("api/Validar", "C", this.Cedula); 
            this.IsValidCedula = (USU_CODIGO>0||USU_CODIGO==-1)?true:false;
                this.ValidCedulaMsg = String.IsNullOrEmpty(this.Cedula) ? "Cédula es Obligatorio" :USU_CODIGO>0?"Cédula ya registrada, consulte con el administrador": USU_CODIGO == -1?"Cédula Invalida":"";

            
                this.IsValidEmail = String.IsNullOrEmpty(this.Email) ? true : false;
            this.IsValidEmail = (String.IsNullOrEmpty(this.Email) ? -1 : await ServiceWebApi.ValidarEmailCedula("api/Validar", "E", this.Email)) != 0 ? true : false;
            this.ValidEmailMsg = String.IsNullOrEmpty(this.Email) ? "Email es Obligatorio" : "Email ya registrado, consulte con el administrador";


            this.IsValidClave = String.IsNullOrEmpty(this.Clave) ? true : false;

           
                this.IsValidClaveRep = (String.IsNullOrEmpty(this.ClaveRepite) || !(this.Clave.Equals(this.ClaveRepite))) ? true : false;

           
                this.IsValidTelefono = String.IsNullOrEmpty(this.Telefono) ? true : false;

            return (!this.IsValidNombres&& !this.IsValidApellidos&& !this.IsValidCedula&& !this.IsValidEmail&& !this.IsValidClave&& !this.IsValidClaveRep&& !this.IsValidTelefono)?true: false;



        }


        

        private void CompletedCommandExecutedAsync(object obj)
        {
            ValidFiled(obj);
        }

        




        public async Task Registrar()
        {
            try
            {
                IsEnabledTxt = false;

                if (await ValidFields())
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
                else
                {
                    await UserDialogs.Instance.AlertAsync("Valide que todos los campos sean correctos!", "Error", "OK");
                    IsEnabledTxt = true;
                }
            }catch(Exception ex)
            {
                await UserDialogs.Instance.AlertAsync("Servicio no disponible, intente más tarde!", "Comunicaciones", "OK");
                
            }
        }



        
    
}
}
