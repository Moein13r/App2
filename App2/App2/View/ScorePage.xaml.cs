using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sharpnado.Shades;
using Xamarin.Forms.Shapes;

namespace App2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScorePage : ContentPage
    {
        Score game;
        GameDatabse db;
        public ScorePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            game = new Score
            {
                name = "ButterFly"
            };
            for (int i = 0; i < 5; i++)
            {
                circles[i] = new Ellipse();
                circles[i].Fill = Brush.Blue;
                Grid.SetRow(circles[i], 0);
                Grid.SetColumn(circles[i], i);
                circles[i].Stroke = Brush.White;
                circles[i].StrokeThickness = 2;
                CircleMaze.Children.Add(circles[i]);
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            db = await Database.GameDatabse.Instnace;
            var record = await db.GetBestScore(game.name);
            record.Add(new Score { score = 800, state = 4 });
            record.Add(new Score { score = 1000, state = 5 });
            Listtop.ItemsSource = record;
            base.OnAppearing();
            for (int i = 0; i < 5; i++)
            {
                Animatee(i);
                await Task.Delay(600);
            }
        }
        Ellipse[] circles = new Ellipse[5];
        private void Animatee(int i)
        {
            Animation f = new Animation(v => circles[i].TranslationY = v, 1, 50, Easing.Linear);
            Animation f1 = new Animation(v => circles[i].TranslationY = v, 50, 1, Easing.Linear);
            Animation parent = new Animation();
            parent.Add(0, 0.5, f);
            parent.Add(0.5, 1, f1);
            parent.Commit(circles[i], "Linear", 20, 1000);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var layout = sender as RelativeLayout;
        }
    }
}