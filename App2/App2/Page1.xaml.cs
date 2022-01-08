using App2.Models;
using App2.View;
using App2.View.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : TabbedPage
    {
        Animation animatee;
        double dwidth = DeviceDisplay.MainDisplayInfo.Width;
        public Page1()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
        }
        protected override void OnAppearing()
        {
            animateframe(r);
            animateframe(r2);
            animateframe(r3);
        }
        private async Task animateframe(Sharpnado.MaterialFrame.MaterialFrame Frame)
        {
            Frame.TranslationX = -dwidth / 2;
            animatee = new Animation(v => Frame.TranslationX = v, -dwidth / 2, 0, Easing.CubicIn);
            base.OnAppearing();
            animatee.Commit(Frame, "Linear", 20, 600);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await (sender as Frame).FadeTo(0.7, 200);
            await (sender as Frame).FadeTo(1, 200);
            var img = (Image)((Grid)(sender as Frame).Content).Children[1];
            //await img.ScaleTo(1.5, 500);
            //await Task.Delay(500);
            //await img.ScaleTo(1, 500);
            await Task.Run(() => animate(img));          
            await Navigation.PushAsync(new MainPage(10, 1000));
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await (sender as Frame).FadeTo(0.7, 200);
            await (sender as Frame).FadeTo(1, 200);
            var img = (Image)((Grid)(sender as Frame).Content).Children[1];
            await Task.Run(() => animate(img));
            await Navigation.PushAsync(new MainPage(15, 800));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await (sender as Frame).FadeTo(0.7, 200);
            await (sender as Frame).FadeTo(1, 200);
            var img = (Image)((Grid)(sender as Frame).Content).Children[1];
            await Task.Run(() => animate(img));
            await Navigation.PushAsync(new MainPage(20, 500));
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            //await PopupNavigation.Instance.PushAsync(new Popup2(),true);
            await PopupNavigation.Instance.PushAsync(new FinalyPopup(true));
        }
        private async Task animate(Image img)
        {
            Animation Scaleup = new Animation(v => img.Scale = v, 0.8, 1.2, Easing.SpringIn);
            Animation Scaledown = new Animation(v => img.Scale = v, 1.2, 0.8, Easing.SpringOut);
            Animation Parent = new Animation();
            Parent.Add(0, 0.5, Scaleup);
            Parent.Add(0.5, 1, Scaledown);
            Parent.Commit(img, "counterAnim", 16, 1000);
            
            await Task.Delay(1000);
        }
    }
}