using App2.Models;
using App2.View.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public  Page1()
        {
            InitializeComponent();

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new MainPage(10,1000));
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage(15,800));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage(20,500));
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popup2());
        }
    }
}