using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequintoBaldeonMovil.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RequintoBaldeonMovil.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventosPage : ContentPage
	{
        ListaEventosViewModel vm;
     

        public EventosPage ()
		{
			InitializeComponent ();
            vm = new ListaEventosViewModel(this.Navigation);
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
          //  await vm.CargarDatos();

            base.OnAppearing();
        }
        protected async void MasInformacion(object sender, EventArgs e)
        {
            /*var button = (Button)sender;
            var row = Grid.GetRow(button);
            var grid = button.Parent as Grid;
            //assuming the image is in column 1
            Convert.ToDecimal(((Label)grid.Children.ElementAt(0)).Text))
           */
            Navigation.PushAsync(new EventoPage(1));
        }
    }
}