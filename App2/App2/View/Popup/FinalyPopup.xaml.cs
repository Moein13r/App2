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
        }
        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}