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
        public Popup1()
        {
            InitializeComponent();
            if (Game.stage == 5)
            {
                Game.stage=1;
                nextstage.IsVisible = false;
                popup.Children.Add(new Label { Text = "تمام مراحل را کامل کردی !", VerticalTextAlignment = TextAlignment.End, HorizontalTextAlignment = TextAlignment.Center, FontSize = 20, FontAttributes = FontAttributes.Bold },0,3);
                popup.Children.Add(new Button { Text = "بازگشت", VerticalOptions=LayoutOptions.End, HorizontalOptions = LayoutOptions.End, FontAttributes = FontAttributes.Bold },3,3);
                //popup.Children[5] = new Label { Text = "تمام مراحل را کامل کردی !", VerticalTextAlignment = TextAlignment.End, HorizontalTextAlignment = TextAlignment.Center, FontSize = 20, FontAttributes = FontAttributes.Bold };
            }
        }
        public async void Button_Clicked()
        {
            await PopupNavigation.Instance.PopAsync();
            await Navigation.PushModalAsync(new Page1());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Game.count += Game.stage * 2;
            Game.speed += Game.stage * 100;
            Game.stage++;
            await PopupNavigation.Instance.PopAsync();
            await Navigation.PushAsync(new MainPage(Game.count, Game.speed));
        }
    }
}