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
            NavigationPage.SetHasNavigationBar(this,true);
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await (sender as Frame).FadeTo(0.7,200);
            await (sender as Frame).FadeTo(1,200);
            var img=(Image)((Grid)(sender as Frame).Content).Children[1];
            //await img.ScaleTo(1.5, 500);
            //await Task.Delay(500);
            //await img.ScaleTo(1, 500);
            await Task.Run(() => animate(ref img));
            await Navigation.PushAsync(new MainPage(10,1000));
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await (sender as Frame).FadeTo(0.7, 200);
            await (sender as Frame).FadeTo(1, 200);
            var img = (Image)((Grid)(sender as Frame).Content).Children[1];
            await Task.Run(() => animate(ref img));
            await Navigation.PushAsync(new MainPage(15,800));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await (sender as Frame).FadeTo(0.7, 200);
            await (sender as Frame).FadeTo(1, 200);
            var img = (Image)((Grid)(sender as Frame).Content).Children[1];
            await Task.Run(() => animate(ref img));
            await Navigation.PushAsync(new MainPage(20,500));
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            //await PopupNavigation.Instance.PushAsync(new Popup2(),true);
            await PopupNavigation.Instance.PushAsync(new FinalyPopup(true));
        }
        private Task animate(ref Image img)
        {
            img.ScaleTo(1.15, 100).Wait();
            img.ScaleTo(1, 100).Wait();
            return Task.CompletedTask;
        }
    }
}