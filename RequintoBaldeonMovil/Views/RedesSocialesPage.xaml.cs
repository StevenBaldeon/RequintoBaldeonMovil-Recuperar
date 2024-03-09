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
    public partial class RedesSocialesPage : ContentPage
    {
        public RedesSocialesPage()
        {
            InitializeComponent();
            
        }

        private void TpFacebook_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.facebook.com/elrequintobaldeon"));
        }

        private void TpInstagram_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.instagram.com/_steven_baldeon_?igsh=YTY3YWRtNmVwbTZ5&utm_source=qr"));
        }

        private void TpTiktok_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.tiktok.com/@stevenbaldeon"));
        }

        private void TpYoutube_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.youtube.com/@ElRequintoBaldeon"));
        }

        private void TpWhatsapp_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://bit.ly/ReservarRB"));
        }
    }
}