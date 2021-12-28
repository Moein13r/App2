using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Result : PopupPage
    {
        public Result(List<int> cans, List<int> uans)
        {

            this.Disappearing += new EventHandler(close);
            InitializeComponent();
            list1 = new List<int>(cans);
            list2 = new List<int>(uans);
            s();
            set_board();
            initialize();
        }
        private async void close(object sender, EventArgs e)
        {
           await Navigation.PopToRootAsync();
        }
        List<int> list1;
        List<int> list2;
        Image[,] f = new Image[5, 5];
        int counter = 0;
        private void initialize()
        {
            if (counter == list1.Count)
                counter = 0;
            if (list1[counter] == list2[counter])
            {
                ((Image)board.Children[list1[counter]]).Source = "Butterfly.png";
                res.Text = "درست حدس زدید";
            }
            else
            {
                ((Image)board.Children[list1[counter]]).Source = "Butterfly.png";
                ((Image)board.Children[list1[counter]]).BackgroundColor = Color.Green;
                ((Image)board.Children[list2[counter]]).Source = "Butterfly.png";
                ((Image)board.Children[list2[counter]]).BackgroundColor = Color.Red;
                res.Text ="اشتباه حدس زدید";
            }
            counter++;
            stage.Text = "مرحله" + counter.ToString();
        }
        private void s()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    f[i, j] = new Image();
                }
            }
        }
        private void set_board()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    f[i, j].Source = "";
                    f[i, j].BackgroundColor = Color.White;
                    board.Children.Add(f[i, j], j, i);
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            set_board();
            initialize();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}