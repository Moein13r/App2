using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App2.Models;
using Rg.Plugins.Popup.Services;
using App2.Views.Popup;
using App2.View.Popup;
using App2.View;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        ImageButton[,] cells;
        public List<int[]> Board = new List<int[]>();
        Game gameplay;
        int Delay;
        int counter;
        int Delay1;
        int counter1;
        [Obsolete]
        public MainPage(int _counter, int _delay)
        {
            for (int i = 0; i < 5; i++)
            {
                Board.Add(new int[] { 0, 0, 0, 0, 0 });
            }
            InitializeComponent();
            Create_Board();
            counter = _counter;
            gameplay = new Game();
            gameplay.set_data();
            Delay = _delay;
            board.IsEnabled = false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Start();
        }
        private async Task Start()
        {
            cells[2, 2].Source = "Butterfly.png";
            await timer();
        }
        //timer Is Game Timer Before start
        public async Task timer()
        {
            counter1 = counter + gameplay.stage * 2;
            Delay1 = Delay - gameplay.stage * 50;
            await Task.Delay(300);
            await play_btn.FadeTo(0,300);
            timerlabel.Text = "3";
            await timerlabel.ScaleTo(2, 1);
            await Task.Delay(1000);
            timerlabel.Text = "2";
            await timerlabel.ScaleTo(1, 1);
            await Task.Delay(1000);
            timerlabel.Text = "1";
            await timerlabel.ScaleTo(2, 1);
            await Task.Delay(1000);
            timerlabel.Text = "شروع";
            play_btn.IsVisible = false;
            await Play();
        }
        public async Task Play()
        {
            Random f = new Random(DateTime.Now.Second);
            for (int i = 0; i < counter1; i++)
            {
                // dir is move direction
                string dir = gameplay.Arrows1[f.Next(0, 7)];
                while (!movep(dir))
                {
                    dir = gameplay.Arrows1[f.Next(0, 7)];
                }
                move(dir);
                Arrow.Source = "";
                await Task.Delay(200);
                ArrowCoordinate(dir);
                await Task.Delay(Delay1);
            }

            timerlabel.Text = "انتخاب کن";
            board.IsEnabled = true;
        }
        //move function is for to move form the current position to target position mathematic
        public bool move(string dir)
        {
            switch (dir)
            {
                case "U":
                        gameplay.indexY -= 1;
                    break;
                case "UR":
                        gameplay.indexY -= 1;
                        gameplay.indexX += 1;
                    break;
                case "R":
                        gameplay.indexX += 1;
                    break;
                case "DR":
                        gameplay.indexY += 1;
                        gameplay.indexX += 1;
                    break;
                case "D":
                        gameplay.indexY += 1;
                    break;
                case "DL":
                        gameplay.indexX -= 1;
                        gameplay.indexY += 1;
                    break;
                case "L":
                        gameplay.indexX -= 1;

                    break;
                case "LU":
                        gameplay.indexX -= 1;
                        gameplay.indexY -= 1;
                    break;

                default:
                    break;
            }
            return true;
        }
        public bool movep(string dir)
        {
            int x = gameplay.indexX;
            int y = gameplay.indexY;
            switch (dir)
            {
                case "U":
                        y -= 1;
                    break;
                case "UR":
                        y -= 1;
                        x += 1;
                    break;
                case "R":
                        x += 1;
                    break;
                case "DR":
                        y += 1;
                        x += 1;
                    break;
                case "D":
                        y += 1;
                    break;
                case "DL":
                        x -= 1;
                        y += 1;        
                    break;
                case "L":
                        x -= 1;
                    break;
                case "LU":
                        x -= 1;
                        y -= 1;
                    break;

                default:
                    break;
            }
            if (x <= 4 && x >= 0 && y <= 4 && y >= 0)
            return true;
            return false;
        }
        // Arrowcoordinate for rotating arrow picture
        public void ArrowCoordinate(string dir)
        {
            Arrow.Source = "Arrow.png";
            Arrow.Rotation = gameplay.Arrows[dir];
        }

        // ButterflyMove is for move butterfly from current position to the target position
        List<int> cans = new List<int>();
        List<int> uans = new List<int>();
        private async void p00_Clicked(object sender, EventArgs e)
        {
            var n = sender as ImageButton;
            var n2 = int.Parse(n.CommandParameter.ToString());
            int index = gameplay.indexX + (gameplay.indexY * 5);
            var f = board.Children[index];
            gameplay.stage++;
            cans.Add(index);
            uans.Add(n2);
            if (gameplay.stage==5)
            {
                await PopupNavigation.Instance.PushAsync(new Result(cans,uans));
                return;
            }
            else
            {
                var popup = new Popup1();
                popup.onClose += popup_onClose;
                await PopupNavigation.Instance.PushAsync(popup);
            }
        }
        private async void popup_onClose(Object s, EventArgs e)
        {
            clear_value();
            await Start();
        }

        [Obsolete]
        private void Create_Board()
        {
            cells = new ImageButton[5, 5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    cells[i, j] = new ImageButton();
                    cells[i, j].CommandParameter = i * 5 + j;
                    cells[i, j].BackgroundColor = Color.White;
                    cells[i, j].Clicked += new EventHandler(p00_Clicked);
                    board.Children.Add(cells[i, j], j, i);
                }
        }
        public bool Calc()
        {
            int sum = 0;
            Board.ForEach(x => Array.ForEach(x, i => sum += i));
            return sum > 2 ? true : false;
            // return true;
        }
        private void clear_value()
        {
            gameplay.set_data();
            stage.Text = "مرحله " + gameplay.stage.ToString();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    cells[i, j].Source = "";
                    cells[i, j].BackgroundColor = Color.White;
                }
        }   
    }
}