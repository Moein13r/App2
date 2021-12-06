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
        Game gameplay;
        int Delay;
        int counter;
        public MainPage(int _counter, int _delay)
        {
            for(int i=0;i<4;i++)
                gameplay.Board.Add(new int[5]);
            InitializeComponent();
            Create_Board();
            counter = _counter;
            Delay = _delay;
            board.IsEnabled = false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Arrow.Source = "";
            await timer();
        }
        //timer Is Game Timer Before start
        public async Task timer()
        {
            timerlabel.Text = "3";
            await Task.Delay(1000);
            timerlabel.Text = "2";
            await Task.Delay(1000);
            timerlabel.Text = "1";
            await Task.Delay(1000);
            timerlabel.Text = "شروع";
            play_btn.IsVisible = false;
            await Play();
        }
        public async Task Play()
        {
            gameplay = new Game();
            Random f = new Random(DateTime.Now.Second);
            for (int i = 0; i < counter; i++)
            {
                // dir is move direction
                string dir = gameplay.Arrows1[f.Next(0, 7)];
                Arrow.Source = "";
                await Task.Delay(200);
                ArrowCoordinate(dir);
                move(dir);
                await Task.Delay(Delay);
            }
            cells[2, 2].Source = "";
            play_btn.IsVisible = true;
            timerlabel.Text = "انتخاب کن";
            gameplay.stage++;
            board.IsEnabled = true;
        }
        //move function is for to move form the current position to target position mathematic
        public void move(string dir)
        {
            switch (dir)
            {
                case "U":
                    if (gameplay.indexY > 0)
                    {
                        gameplay.indexY -= 1;
                    }
                    break;
                case "UR":
                    if (gameplay.indexY > 0 && gameplay.indexX < 4)
                    {
                        gameplay.indexY -= 1;
                        gameplay.indexX += 1;
                    }
                    break;
                case "R":
                    if (gameplay.indexX < 4)
                        gameplay.indexX += 1;
                    break;
                case "DR":
                    if (gameplay.indexX < 4 && gameplay.indexY < 4)
                    {
                        gameplay.indexY += 1;
                        gameplay.indexX += 1;
                    }
                    break;
                case "D":
                    if (gameplay.indexY < 4)
                        gameplay.indexY += 1;
                    break;
                case "DL":
                    if (gameplay.indexX > 0 && gameplay.indexY < 4)
                    {
                        gameplay.indexX -= 1;
                        gameplay.indexY += 1;
                    }
                    break;
                case "L":
                    if (gameplay.indexX > 0)
                        gameplay.indexX -= 1;
                    break;
                case "LU":
                    if (gameplay.indexY > 0 && gameplay.indexX > 0)
                    {
                        gameplay.indexX -= 1;
                        gameplay.indexY -= 1;
                    }
                    break;

                default:
                    break;
            }
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
            if (n.Id == f.Id)
            {
                gameplay.Board[gameplay.indexX][gameplay.indexY] = 1;
                n.BackgroundColor = new Color(0, 250, 0);
            }
            else
            {
                n.BackgroundColor = new Color(150,0,0);
            }
            if (gameplay.stage==5)
            {
                await PopupNavigation.PushAsync(new FinalyPopup(gameplay.Calc()));
            }
            else
            {
                var popup = new Popup1();
                popup.onClose += popup_onClose;
                await PopupNavigation.Instance.PushAsync(popup);
            }
        }
        private void popup_onClose(Object s, EventArgs e)
        {
            clear_value();
            counter += gameplay.stage * 2;
            Delay -= gameplay.stage * 50;
        }
        private void Create_Board()
        {
            cells = new ImageButton[5, 5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    cells[i, j].BackgroundColor = new Color(0, 0, 250);
                    board.Children.Add(cells[i, j], j, i);
                }
        }
        private void clear_value()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    cells[i, j].Source = "";
                    cells[i, j].BackgroundColor=new Color(0,0,250);
                }
            cells[2, 2].Source = "Butterfly.png";
        }   
    }
}