using App2.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace App2.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popup1 : PopupPage
    {
        public event EventHandler onClose;
        public Popup1()
        {
            InitializeComponent();
        }
        public async void Button_Clicked()
        {
            await PopupNavigation.Instance.PopAsync();
            await Navigation.PushModalAsync(new Page1());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            onClose.Invoke(sender, e);
            await PopupNavigation.Instance.PopAsync();
            //await Navigation.PushAsync(new MainPage(Game.count, Game.speed));
            //await Navigation.PopAsync();
        }
    }
}