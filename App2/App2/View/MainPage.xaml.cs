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
            Delay = _delay;
            board.IsEnabled = false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            gameplay = new Game();
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
                while (!move(dir))
                {
                    dir = gameplay.Arrows1[f.Next(0, 7)];
                }
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
                    if (gameplay.indexY > 0)
                    {
                        gameplay.indexY -= 1;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "UR":
                    if (gameplay.indexY > 0 && gameplay.indexX < 4)
                    {
                        gameplay.indexY -= 1;
                        gameplay.indexX += 1;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "R":
                    if (gameplay.indexX < 4)
                        gameplay.indexX += 1;
                    else
                        return false;
                    break;
                case "DR":
                    if (gameplay.indexX < 4 && gameplay.indexY < 4)
                    {
                        gameplay.indexY += 1;
                        gameplay.indexX += 1;
                    }
                    else
                        return false;
                    break;
                case "D":
                    if (gameplay.indexY < 4)
                        gameplay.indexY += 1;
                    else
                        return false;
                    break;
                case "DL":
                    if (gameplay.indexX > 0 && gameplay.indexY < 4)
                    {
                        gameplay.indexX -= 1;
                        gameplay.indexY += 1;
                    }
                    else
                        return false;
                    break;
                case "L":
                    if (gameplay.indexX > 0)
                        gameplay.indexX -= 1;
                    else
                        return false;
                    break;
                case "LU":
                    if (gameplay.indexY > 0 && gameplay.indexX > 0)
                    {
                        gameplay.indexX -= 1;
                        gameplay.indexY -= 1;
                    }
                    else
                        return false;
                    break;

                default:
                    break;
            }
            return true;
        }
        // Arrowcoordinate for rotating arrow picture
        public void ArrowCoordinate(string dir)
        {
            Arrow.Source = "Arrow.png";
            Arrow.Rotation = gameplay.Arrows[dir];
        }

        // ButterflyMove is for move butterfly from current position to the target position
        [Obsolete]
        private async void p00_Clicked(object sender, EventArgs e)
        {
            cells[gameplay.indexY, gameplay.indexX].Source = "Butterfly.png";
            var n = sender as ImageButton;
            int index = gameplay.indexX + (gameplay.indexY * 5);
            var f = board.Children[index];
            gameplay.stage++;
            if (n.Id == f.Id)
            {
                Board[gameplay.indexX][gameplay.indexY]++;
                n.BackgroundColor = new Color(0, 250, 0);
            }
            else
            {
                n.BackgroundColor = new Color(150,0,0);
            }
            if (gameplay.stage==5)
            {
                await PopupNavigation.PushAsync(new FinalyPopup(Calc()));
                return ;
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
            counter1 =counter + gameplay.stage * 2;
            Delay1 = Delay - gameplay.stage * 50;
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