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
    public partial class Page1 : TabbedPage
    {
        bool isbusy = false;
        public  Page1()
        {
            NavigationPage.SetHasNavigationBar(this,true);
            InitializeComponent();
            //this.Children.Add();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (isbusy)
                return;
            isbusy = true;
            await (sender as Frame).FadeTo(0.7,200);
            await (sender as Frame).FadeTo(1,200);
            var img=(Image)((Grid)(sender as Frame).Content).Children[1];
            //await img.ScaleTo(1.5, 500);
            //await Task.Delay(500);
            //await img.ScaleTo(1, 500);
            await animate(img);
            await Navigation.PushAsync(new MainPage(10,1000));
            isbusy = false;
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await (sender as Frame).FadeTo(0.7, 200);
            await (sender as Frame).FadeTo(1, 200);
            var img = (Image)((Grid)(sender as Frame).Content).Children[1];
            await animate(img);
            await Navigation.PushAsync(new MainPage(15,800));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await (sender as Frame).FadeTo(0.7, 200);
            await (sender as Frame).FadeTo(1, 200);
            var img = (Image)((Grid)(sender as Frame).Content).Children[1];
            await animate(img);
            await Navigation.PushAsync(new MainPage(20,500));
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            //await PopupNavigation.Instance.PushAsync(new Popup2(),true);
            await PopupNavigation.Instance.PushAsync(new Popup2());
        }
        private async Task animate(Image img)
        {
            Animation animate = new Animation(v => img.Scale = v,0.8,2,Easing.SpringIn);
            Animation animate1 = new Animation(v => img.Scale = v, 2, 1, Easing.SpringOut);
            Animation animateP = new Animation();
            animateP.Add(0,0.5,animate);
            animateP.Add(0.5,1,animate1);
            animateP.Commit(img,"counterAnim",16,1000);
            await Task.Delay(1000);
        }
    }
}