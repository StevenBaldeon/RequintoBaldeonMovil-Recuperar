using RequintoBaldeonMovil.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RequintoBaldeonMovil.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}