using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using RequintoBaldeonMovil.Models;
using Acr.UserDialogs;
using RequintoBaldeonMovil.Models;
using System.Diagnostics.Tracing;

namespace RequintoBaldeonMovil.ViewModels
{
    public class EventoViewModel : BaseViewModel
    {
        private Evento evento;

        public string controlador = "/api/Eventos/E";

        private string imagen;

        public string Imagen
        {
            get => evento.EVE_IMAGEN;
            set { evento.EVE_IMAGEN = value; OnPropertyChanged(); }
        }


        private string nombre;

        public string Nombre
        {
            get => evento.EVE_NOMBRE;
            //get { return nombre; }
            set { evento.EVE_NOMBRE = value; OnPropertyChanged(); }
        }


        private string fecha;

        public string Fecha
        {
            get => evento.EVE_FECHA;
            //get { return nombre; }
            set { evento.EVE_FECHA = value; OnPropertyChanged(); }
        }

        private string precio;

        public string Precio
        {
            get => evento.EVE_PRECIO_ENTRADA;
            set { evento.EVE_PRECIO_ENTRADA = value; OnPropertyChanged(); }
        }



        public ICommand ComandoActualizar { private set; get; }


        public EventoViewModel(Evento p = null)
        {
            evento = p ?? new Evento() { EVE_CODIGO = decimal.Zero };


            /*
             if (p != null)
                producto = p;
            else
                producto = new Producto();
            */
           
        }

       
       

    }
}
