﻿using System;
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

namespace App2
{
    public partial class MainPage : ContentPage
    {
        Game gameplay;
        int Delay;
        int counter;
        public MainPage(int _counter,int _delay)
        {
            InitializeComponent();
            stage.Text ="stage" + Game.stage.ToString();
            counter = _counter;
            Delay = _delay;
            board.IsEnabled = false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Arrow.Source = "";
            p22.Source = "Butterfly.png";
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
            timerlabel.Text="شروع";
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
            p22.Source = "";
            play_btn.IsVisible = true;
            timerlabel.Text = "انتخاب کن";
            gameplay.Board[gameplay.indexX, gameplay.indexY] = 1;
            ButterFlyMove("");
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
        public void ButterFlyMove(string source)
        {
            if (gameplay.indexY == 0)
            {
                if (gameplay.indexX == 0)
                {
                    p00.Source = source;
                }
                else if (gameplay.indexX == 1)
                {
                    p01.Source = source;
                }
                else if (gameplay.indexX == 2)
                {
                    p02.Source = source;
                }
                else if (gameplay.indexX == 3)
                {
                    p03.Source = source;
                }
                else
                {
                    p04.Source = source;
                }
            }
            else if (gameplay.indexY == 1)
            {
                if (gameplay.indexX == 0)
                {
                    p10.Source = source;
                }
                else if (gameplay.indexX == 1)
                {
                    p11.Source = source;
                }
                else if (gameplay.indexX == 2)
                {
                    p12.Source = source;
                }
                else if (gameplay.indexX == 3)
                {
                    p13.Source = source;
                }
                else
                {
                    p14.Source = source;
                }
            }
            else if (gameplay.indexY == 2)
            {
                if (gameplay.indexX == 0)
                {
                    p20.Source = source;
                }
                else if (gameplay.indexX == 1)
                {
                    p21.Source = source;
                }
                else if (gameplay.indexX == 2)
                {
                    p22.Source = source;
                }
                else if (gameplay.indexX == 3)
                {
                    p23.Source = source;
                }
                else
                {
                    p24.Source = source;
                }
            }
            else if (gameplay.indexY == 3)
            {
                if (gameplay.indexX == 0)
                {
                    p30.Source = source;
                }
                else if (gameplay.indexX == 1)
                {
                    p31.Source = source;
                }
                else if (gameplay.indexX == 2)
                {
                    p32.Source = source;
                }
                else if (gameplay.indexX == 3)
                {
                    p33.Source = source;
                }
                else
                {
                    p34.Source = source;
                }
            }
            else
            {
                if (gameplay.indexX == 0)
                {
                    p40.Source = source;
                }
                else if (gameplay.indexX == 1)
                {
                    p41.Source = source;
                }
                else if (gameplay.indexX == 2)
                {
                    p42.Source = source;
                }
                else if (gameplay.indexX == 3)
                {
                    p43.Source = source;
                }
                else
                {
                    p44.Source = source;
                }
            }
        }
        private async void p00_Clicked(object sender, EventArgs e)
        {
            //ImageButton n= new ImageButton();
            
            var n = sender as ImageButton;
            int index = gameplay.indexX+(gameplay.indexY*5);
            var f = board.Children[index];
            if (n.Id == f.Id)
            {
                n.BackgroundColor = new Color(10, 250, 10);
                await PopupNavigation.Instance.PushAsync(new Popup1());
                n.BackgroundColor = new Color(0, 250, 0);
            }
            else
            {
                n.BackgroundColor = new Color(100, 0, 0);
                await DisplayAlert("اشتباه!", "دوباره سعی کن", "برگشت");
                Game.stage = 1;
                await Navigation.PopAsync();
            }
            ButterFlyMove("Butterfly.png");

        }
    }
}