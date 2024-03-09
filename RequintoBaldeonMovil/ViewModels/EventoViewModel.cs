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
using RequintoBaldeonMovil.Services;
using System.Collections.ObjectModel;

namespace RequintoBaldeonMovil.ViewModels
{
    public class EventoViewModel : BaseViewModel
    {
        private Evento evento;

        public string controlador = "/api/Eventos/E";

        private decimal id;

        public decimal Id
        {
            get => evento.EVE_CODIGO;
            set { evento.EVE_CODIGO = value; OnPropertyChanged(); }
        }

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


        private string descripcion;

        public string Descripcion
        {
            get => evento.EVE_DESCRIPCION;
            set { evento.EVE_DESCRIPCION = value; OnPropertyChanged(); }
        }


        private string hora;

        public string Hora
        {
            get => evento.EVE_HORA;
            set { evento.EVE_HORA = value; OnPropertyChanged(); }
        }

        private string ubicacion;

        public string Ubicacion
        {
            get => "https://maps.google.com/?q="+evento.EVE_UBICACION;
            set { evento.EVE_UBICACION = value; OnPropertyChanged(); }
        }


        private string direccion;
        public string Direccion
        {
            get => evento.EVE_DIRECCION;
            set { evento.EVE_DIRECCION = value; OnPropertyChanged(); }
        }

        private ObservableCollection<EventoViewModel> eventos;

        public ObservableCollection<EventoViewModel> Eventos
        {
            get => eventos;
            set { eventos = value; OnPropertyChanged(); }
        }

        public ICommand ComandoActualizar { private set; get; }
        public ICommand ComandoCargarDatos { private set; get; }

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

        public EventoViewModel(decimal id)
        {
            try
            {
                ComandoCargarDatos = new Command(async () => await CargarDatos(id));

                CargarDatos(id);
            }catch (Exception ex) { 
            throw ex;
            }
        }


    

        public async Task CargarDatos(decimal id)
        {
            //List<Producto> productos = Servicios.ServicioDatos.ObtenerProductos();
            //List<Producto> productos = new List<Producto>();
            try
            {
                List<Evento> evento = await ServiceWebApi.ObtenerEvento("api/Eventos", id.ToString());



                //  EventoViewModel eventosVM = new EventoViewModel();
                List<EventoViewModel> eventosVM = new List<EventoViewModel>();

                foreach (Evento p in evento)
                {
                    eventosVM.Add(new EventoViewModel(p));
                }

                Eventos = new ObservableCollection<EventoViewModel>(eventosVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }



      

}
