using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App2.Models;
using System.Threading;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        Game gameplay = new Game();
        public MainPage()
        {
            InitializeComponent();
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
            timerlabel.Text = "Running";
            play_btn.IsVisible = false;
            await arrows();
        }
        public async Task arrows()
        {
            Random f = new Random(DateTime.Now.Second);
            for (int i = 0; i < 10; i++)
            {
                // dir is move direction
                string dir = gameplay.Arrows1[f.Next(0, 7)];
                pictureCoordinate(dir);
                move(dir);
                await Task.Delay(2000);
            }
            play_btn.IsVisible = true;
            timerlabel.Text = "Tap Play To Start";
            
            gameplay.Board[gameplay.indexX, gameplay.indexY] = 1;
        }
        //move function is for to move form the current position to target position
        public void move(string dir)
        {
            switch (dir)
            {
                case "U":
                    if (gameplay.indexY > 0)
                        gameplay.indexY -= 1;
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
                    if (gameplay.indexY > 0)
                        gameplay.indexY -= 1;
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
        // picturecoordinate for rotating arrow picture
        public void pictureCoordinate(string dir)
        {
            Arrow.Source = "Arrow.png";
            Arrow.Rotation = gameplay.Arrows[dir];
        }
    }
}