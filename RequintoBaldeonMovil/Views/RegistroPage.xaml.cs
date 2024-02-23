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
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
            this.BindingContext = new RegistroViewModel(this.Navigation);
        }

        private void BtnRegistro_Clicked(object sender, EventArgs e)
        {

        }
    }
}