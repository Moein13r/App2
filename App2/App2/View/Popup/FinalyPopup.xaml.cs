using Rg.Plugins.Popup.Pages;
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
                mood.Source = "t.jpg";
            }
            else
            {
                content.BackgroundColor = Color.DodgerBlue;
                resualt.Text = "دوباره امتحان کنید";
                mood.Source = "th.jpg";
            }
        }
    }
}