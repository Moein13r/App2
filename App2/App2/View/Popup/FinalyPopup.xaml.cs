using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.View.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinalyPopup : PopupPage
    {
        public FinalyPopup(bool res)
        {
            InitializeComponent();
            design(res);
        }
        private void design(bool res)
        {
            if(res)
            {
                content.BackgroundColor = new Color(100,50,10);
                resualt.Text = "تبریک!";
                mood.Source = "h.jpg";
            }
            else
            {
                content.BackgroundColor = Color.DodgerBlue;
                resualt.Text = "دوباره امتحان کنید";
                mood.Source = "th.jpg";
            }
        }
        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync(true);
            await Navigation.PopAsync(true);
            await Navigation.PushAsync(new Page1());
        }
    }
}