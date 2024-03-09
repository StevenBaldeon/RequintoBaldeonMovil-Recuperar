using RequintoBaldeonMovil.Models;
using RequintoBaldeonMovil.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RequintoBaldeonMovil.ViewModels
{
    class PatrocinadorViewModel : BaseViewModel
    {
        private Patrocinador patrocinador;

        public string controlador = "/api/Patrocinadores/P";

        private decimal id;

        public decimal Id
        {
            get => patrocinador.PAT_CODIGO;
            set { patrocinador.PAT_CODIGO = value; OnPropertyChanged(); }
        }

        public string Logo
        {
            get => patrocinador.PAT_LOGO;
            set { patrocinador.PAT_LOGO = value; OnPropertyChanged(); }
        }


        private string nombre;

        public string Nombre
        {
            get => patrocinador.PAT_NOMBRE;
            //get { return nombre; }
            set { patrocinador.PAT_NOMBRE = value; OnPropertyChanged(); }
        }


        private string email;

        public string Email
        {
            get => patrocinador.PAT_EMAIL;
            //get { return nombre; }
            set { patrocinador.PAT_EMAIL = value; OnPropertyChanged(); }
        }

        private string telefono;

        public string Telefono
        {
            get => patrocinador.PAT_TELEFONO;
            set { patrocinador.PAT_TELEFONO = value; OnPropertyChanged(); }
        }


        private string direccion;

        public string Direccion
        {
            get => patrocinador.PAT_DIRECCION;
            set { patrocinador.PAT_DIRECCION = value; OnPropertyChanged(); }
        }


        private string paginaweb;

        public string Paginaweb
        {
            get => patrocinador.PAT_PAGINA_WEB;
            set { patrocinador.PAT_PAGINA_WEB = value; OnPropertyChanged(); }
        }

        private string rrss;

        public string RRSS
        {
            get => patrocinador.PAT_RRSS;
            set { patrocinador.PAT_RRSS = value; OnPropertyChanged(); }
        }


        private string observacion;
        public string Observacion
        {
            get => patrocinador.PAT_OBSERVACION;
            set { patrocinador.PAT_OBSERVACION = value; OnPropertyChanged(); }
        }

       

        public PatrocinadorViewModel(Patrocinador p = null)
        {
            patrocinador = p ?? new Patrocinador() { PAT_CODIGO = decimal.Zero };


            /*
             if (p != null)
                producto = p;
            else
                producto = new Producto();
            */

        }



    }


    
    
}
