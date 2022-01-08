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
    public partial class ShapeGame : ContentPage
    {
        List<int> row = new List<int> { 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7 };
        List<int> col = new List<int> { 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7 };
        List<int> pattern = new List<int> { 1, 2, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
        Grid Board;
        ImageButton[,] img;
        int Counter;
        int Stage;
        int Score;
        Label timer = new Label { TextColor = Color.White, FontSize = 20 };
        Frame frame = new Frame { CornerRadius = 22, BackgroundColor = Color.DodgerBlue, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 50), IsClippedToBounds = true };
        HashSet<int> index;
        Label[] result = new Label[21];
        int userchoose = 0;
        int correct_answer = 0;
        int CompletedStage = 0;
        public ShapeGame()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            Grid.SetRow(frame, 1);
            Content.Children.Add(frame);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Stage = 0;
            Counter = 0;
            Score = 0;
            Timer();
            (sender as Button).IsVisible = false;
        }
        private async void Timer()
        {
            frame.Content = timer;
            frame.IsVisible = true;
            Animation ParentAnimation = new Animation();
            Animation ParentAnimation1 = new Animation();
            Animation animate = new Animation(v => frame.Scale = v, 1, 0.5, Easing.SpringIn);
            Animation animate1 = new Animation(v => frame.Scale = v, 0.5, 1, Easing.SpringOut);
            ParentAnimation.Add(0, 0.5, animate);
            ParentAnimation.Add(0.5, 1, animate1);
            timer.Text = "3";
            ParentAnimation.Commit(frame, "counterAnim", 20, 1000);
            await Task.Delay(1000);
            timer.Text = "2";
            ParentAnimation.Commit(frame, "counterAnim", 20, 1000);
            await Task.Delay(1000);
            timer.Text = "1";
            ParentAnimation.Commit(frame, "counterAnim", 20, 1000);
            await Task.Delay(1000);
            frame.IsVisible = false;
            await Play();
        }
        private async Task Play()
        {
            if (Stage <= 20)
            {
                Instance.Text = "";
                stage.Text = Stage.ToString();
                Create_Board(row[Counter], col[Counter]);
                Click_button(row[Counter], col[Counter]);
                Pattern();
                Board.IsEnabled = false;
                instane2.IsVisible = true;
                showanswer(Color.DodgerBlue);
                await Task.Delay(2000);
                instane2.IsVisible = false;
                Board.IsEnabled = true;
                Instance.Text = "انتخاب کن";
                showanswer(Color.White);
                Stage++;
            }
            else
            {
                Create_Board(5, 4);
                Board.IsEnabled = false;
                show_resualt();
                Instance.Text = "نتایج";
                await Task.Delay(8000);
                await Navigation.PopToRootAsync();
            }
        }
        private void show_resualt()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int temp = (i * 4) + j;
                    result[temp].BackgroundColor = Color.White;
                    result[temp].TextColor = Color.DodgerBlue;
                    result[temp].VerticalTextAlignment = TextAlignment.Center;
                    result[temp].HorizontalTextAlignment = TextAlignment.Center;
                    result[temp].FontAttributes = FontAttributes.Bold;
                    Board.Children.Add(result[temp], j, i);
                }
            }
            instane2.Text = $"{CompletedStage}/20";
        }
        private void showanswer(Color r)
        {
            for (int i = 0; i < index.Count; i++)
            {
                var img = ((ImageButton)Board.Children[index.ElementAt(i)]);
                if (r == Color.LightGreen && img.BackgroundColor == Color.DodgerBlue)
                {
                    img.BackgroundColor = Color.ForestGreen;
                    img.RelRotateTo(180, 200);
                    continue;
                }
                if (r == Color.LightGreen)
                {
                    img.BackgroundColor = Color.FromHex("#81B29A");
                }
                else
                {
                    img.BackgroundColor = r;
                }
                img.RelRotateTo(180, 200);
            }
        }
        private void Pattern()
        {
            index = new HashSet<int>();
            int c = rand.Next(col[Counter], row[Counter] + pattern[Counter]);
            for (int i = 0; i < c; i++)
            {
                int r = rand.Next(0, col[Counter] * row[Counter] - 1);
                while (index.Contains(r))
                {
                    r = rand.Next(0, col[Counter] * row[Counter] - 1);
                }
                index.Add(r);
            }
        }
        Random rand = new Random();
        private async void ImgBtnClicked(object sender, EventArgs e)
        {
            if (!isenable[int.Parse((sender as ImageButton).AutomationId)])
                return;
            isenable[int.Parse((sender as ImageButton).AutomationId)] = false;
            checkAnswer(sender as ImageButton);

            if (userchoose == index.Count)
            {
                showanswer(Color.LightGreen);
                Board.IsEnabled = false;
                if (correct_answer == userchoose)
                {
                    Counter++;
                    Lottie.Animation = "correct.json";
                    Lottie.IsVisible = true;
                    await Task.Delay(800);
                    Lottie.IsVisible = false;
                    CompletedStage++;
                }
                else
                {
                    Lottie.Animation = "wrong.json";
                    Lottie.IsVisible = true;
                    await Task.Delay(800);
                    Lottie.IsVisible = false;
                    Counter = Counter > 0 ? Counter - 1 : 0;
                    await Task.Delay(1000);
                }
                result[Stage - 1] = new Label();
                result[Stage - 1].Text = $"{(correct_answer * 100 / userchoose).ToString()} %";
                correct_answer = 0;
                Content.Children.Remove(Board);
                userchoose = 0;
                Play();
            }
        }
        List<bool> isenable;
        private void checkAnswer(ImageButton sender)
        {
            bool Istrue = false;
            var img = new ImageButton();
            for (int i = 0; i < index.Count; i++)
            {
                img = ((ImageButton)Board.Children[index.ElementAt(i)]);
                if (img.Id == sender.Id)
                {
                    Istrue = true;
                    break;
                }
            }
            sender.RelRotateTo(180, 200);
            if (Istrue)
            {
                sender.BackgroundColor = Color.DodgerBlue;
                correct_answer++;
                Score += 70;
            }
            else
            {
                Score = Score >= 70 ? Score - 70 : 0;
                sender.BackgroundColor = Color.Red;
            }
            Scorelabel.Text = Score.ToString();
            userchoose++;
        }
        private void Create_Board(int r, int c)
        {
            isenable = new List<bool>();
            Board = new Grid();
            for (int i = 0; i < c; i++)
            {
                Board.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }
            for (int i = 0; i < r; i++)
            {
                Board.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            }
            img = new ImageButton[r, c];
            Board.Margin = new Thickness(50, 20);
            Board.Padding = new Thickness(10);
            Board.BackgroundColor = Color.Black;
            Grid.SetRow(Board, 1);
            Content.Children.Add(Board);
        }
        private void Click_button(int r, int c)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    img[i, j] = new ImageButton();
                    isenable.Add(true);
                    img[i, j].AutomationId = ((i * col[Counter]) + j).ToString();
                    img[i, j].Clicked += new EventHandler(ImgBtnClicked);
                    img[i, j].BackgroundColor = Color.White;
                    Grid.SetRow(img[i, j], i);
                    Grid.SetColumn(img[i, j], j);
                    Board.Children.Add(img[i, j]);
                }
            }
        }
    }
}