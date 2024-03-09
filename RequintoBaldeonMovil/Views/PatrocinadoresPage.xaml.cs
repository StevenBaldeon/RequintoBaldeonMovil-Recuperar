using RequintoBaldeonMovil.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RequintoBaldeonMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatrocinadoresPage : ContentPage
    {
        ListaPatrocinadoresViewModel vm;
        public PatrocinadoresPage()
        {
            InitializeComponent();
            vm = new ListaPatrocinadoresViewModel(this.Navigation);
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            //  await vm.CargarDatos();

            base.OnAppearing();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}