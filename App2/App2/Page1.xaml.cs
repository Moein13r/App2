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
            Game.speed = 1000;
            Game.count = 10;
           await Navigation.PushModalAsync(new MainPage(Game.count ,Game.speed));
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Game.speed = 800;
            Game.count = 15;
            await Navigation.PushModalAsync(new MainPage(Game.count,Game.speed));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            Game.speed = 500;
            Game.count = 20;
            await Navigation.PushModalAsync(new MainPage(Game.count,Game.speed));
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popup2());
        }
    }
}