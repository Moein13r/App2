using App2.View.Popup;
using App2.Views.Popup;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
master

            MainPage = new Page1();
            NavigationPage navi = new NavigationPage(new Page1());
            MainPage = navi;
orgi
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
