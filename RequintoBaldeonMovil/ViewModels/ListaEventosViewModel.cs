using System;

using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

using RequintoBaldeonMovil.Models;
using RequintoBaldeonMovil.Services;

namespace RequintoBaldeonMovil.ViewModels
{
    public class ListaEventosViewModel : BaseViewModel
    {
        private ObservableCollection<EventoViewModel> eventos;

        public ObservableCollection<EventoViewModel> Eventos
        {
            get => eventos;
            set { eventos = value; OnPropertyChanged(); }
        }

        private EventoViewModel eventoSeleccionado;

        public EventoViewModel EventoSeleccionado
        {
            get => eventoSeleccionado;
            set { eventoSeleccionado = value; OnPropertyChanged(); }
        }

        private bool estaActualizando;

        public bool EstaActualizando
        {
            get => estaActualizando;
            set { estaActualizando = value; OnPropertyChanged(); }
        }

        public ICommand ComandoVerDetalles { private set; get; }
        public ICommand ComandoAltaProducto { private set; get; }
        public ICommand ComandoCargarDatos { private set; get; }

        public INavigation Navegacion { get; set; }

        public ListaEventosViewModel(INavigation n)
        {
            Navegacion = n;
            ComandoVerDetalles = new Command<Type>(async (pagina) => await VerDetalles(pagina));

            ComandoAltaProducto = new Command<Type>(async (pagina) => await AltaProducto(pagina));
            ComandoCargarDatos = new Command(async () => await CargarDatos());

            CargarDatos();
        }

        public async Task CargarDatos()
        {
            //List<Producto> productos = Servicios.ServicioDatos.ObtenerProductos();
            //List<Producto> productos = new List<Producto>();

            List<Evento> eventos = await ServiceWebApi.ObtenerItems<Evento>("api/Eventos/E");

            List <EventoViewModel> eventosVM = new List<EventoViewModel>();

            foreach (Evento p in eventos)
            {
                eventosVM.Add(new EventoViewModel(p));
            }

            Eventos = new ObservableCollection<EventoViewModel>(eventosVM);

            EstaActualizando = false;
        }

        async Task VerDetalles(Type p)
        {
            if (EventoSeleccionado != null)
            {
                Page pagina = (Page)Activator.CreateInstance(p);
                pagina.BindingContext = EventoSeleccionado;

                await Navegacion.PushAsync(pagina);
            }
        }

        async Task AltaProducto(Type p)
        {
            Page pagina = (Page)Activator.CreateInstance(p);
            pagina.BindingContext = new EventoViewModel();

            await Navegacion.PushAsync(pagina);
        }
    }
}
