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
    public partial class EventoPage : ContentPage
    {
        ListaEventosViewModel vm;
        public EventoPage(decimal id)
        {
            InitializeComponent();
            vm = new ListaEventosViewModel(id);
            BindingContext = vm; 
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {

        }
    }
}