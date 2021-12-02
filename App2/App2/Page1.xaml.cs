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
            PopupNavigation.Instance.PushAsync(new App2.Views.Popup.Popup1());
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
    }
}