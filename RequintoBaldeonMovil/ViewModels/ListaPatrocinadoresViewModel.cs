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
    class ListaPatrocinadoresViewModel : BaseViewModel
    {
        private ObservableCollection<PatrocinadorViewModel> patrocinadores;

        public ObservableCollection<PatrocinadorViewModel> Patrocinadores
        {
            get => patrocinadores;
            set { patrocinadores = value; OnPropertyChanged(); }
        }

        private PatrocinadorViewModel patrocinadorSeleccionado;

        public PatrocinadorViewModel PatrocinadorSeleccionado
        {
            get => patrocinadorSeleccionado;
            set { patrocinadorSeleccionado = value; OnPropertyChanged(); }
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

        public ListaPatrocinadoresViewModel(INavigation n)
        {
            Navegacion = n;
            ComandoVerDetalles = new Command<Type>(async (pagina) => await VerDetalles(pagina));

            ComandoAltaProducto = new Command<Type>(async (pagina) => await AltaProducto(pagina));
            ComandoCargarDatos = new Command(async () => await CargarDatos());

            CargarDatos();
        }

        public ListaPatrocinadoresViewModel(decimal id)
        {

            ComandoCargarDatos = new Command(async () => await CargarDatos());

            CargarDatos(id.ToString());
        }

        public async Task CargarDatos()
        {
            //List<Producto> productos = Servicios.ServicioDatos.ObtenerProductos();
            //List<Producto> productos = new List<Producto>();

            List<Patrocinador> patrocinadores = await ServiceWebApi.ObtenerItems<Patrocinador>("api/PAtrocinadores/P");

            List<PatrocinadorViewModel> patrocionadoresVM = new List<PatrocinadorViewModel>();

            foreach (Patrocinador p in patrocinadores)
            {
                patrocionadoresVM.Add(new PatrocinadorViewModel(p));
            }

            Patrocinadores = new ObservableCollection<PatrocinadorViewModel>(patrocionadoresVM);

            EstaActualizando = false;
        }

        public async Task CargarDatos(string id)
        {
            //List<Producto> productos = Servicios.ServicioDatos.ObtenerProductos();
            //List<Producto> productos = new List<Producto>();

            List<Patrocinador> patrocinadores = await ServiceWebApi.ObtenerItems<Patrocinador>("api/Patrocinadores/" + id);

            List<PatrocinadorViewModel> patrociandoresVM = new List<PatrocinadorViewModel>();

            foreach (Patrocinador p in patrocinadores)
            {
                patrociandoresVM.Add(new PatrocinadorViewModel(p));
            }

            Patrocinadores = new ObservableCollection<PatrocinadorViewModel>(patrociandoresVM);

            EstaActualizando = false;
        }

        async Task VerDetalles(Type p)
        {
            if (PatrocinadorSeleccionado != null)
            {
                Page pagina = (Page)Activator.CreateInstance(p);
                pagina.BindingContext = PatrocinadorSeleccionado;

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

