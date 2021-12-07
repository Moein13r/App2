using System;
using System.Timers;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace App2.Models
{
    class Game
    {
        public Game()
        {
        }
        public string[] Arrows1 = { "U", "UR", "R", "DR", "D", "DL", "L", "LU" };
        public Dictionary<string, int> Arrows = new Dictionary<string, int>() { { "U", -90 }, { "UR", -45 }, { "R", 0 }, { "DR", 45 }, { "D", 90 }, { "DL", 135 }, { "L", 180 }, { "LU", 225 } };
        //public int[,] board = new int[5,5];
        public int indexX;
        public int indexY;
        public int stage = 1;
        public int count { get; set; }
        public int speed { set; get; }
        public void set_data()
        {
            this.indexX = 2;
            this.indexY = 2;
        }
    }
    //public void ButterFlyMove(string source)
    //{
    //    if (gameplay.indexY == 0)
    //    {
    //        if (gameplay.indexX == 0)
    //        {
    //            p00.Source = source;
    //        }
    //        else if (gameplay.indexX == 1)
    //        {
    //            p01.Source = source;
    //        }
    //        else if (gameplay.indexX == 2)
    //        {
    //            p02.Source = source;
    //        }
    //        else if (gameplay.indexX == 3)
    //        {
    //            p03.Source = source;
    //        }
    //        else
    //        {
    //            p04.Source = source;
    //        }
    //    }
    //    else if (gameplay.indexY == 1)
    //    {
    //        if (gameplay.indexX == 0)
    //        {
    //            p10.Source = source;
    //        }
    //        else if (gameplay.indexX == 1)
    //        {
    //            p11.Source = source;
    //        }
    //        else if (gameplay.indexX == 2)
    //        {
    //            p12.Source = source;
    //        }
    //        else if (gameplay.indexX == 3)
    //        {
    //            p13.Source = source;
    //        }
    //        else
    //        {
    //            p14.Source = source;
    //        }
    //    }
    //    else if (gameplay.indexY == 2)
    //    {
    //        if (gameplay.indexX == 0)
    //        {
    //            p20.Source = source;
    //        }
    //        else if (gameplay.indexX == 1)
    //        {
    //            p21.Source = source;
    //        }
    //        else if (gameplay.indexX == 2)
    //        {
    //            p22.Source = source;
    //        }
    //        else if (gameplay.indexX == 3)
    //        {
    //            p23.Source = source;
    //        }
    //        else
    //        {
    //            p24.Source = source;
    //        }
    //    }
    //    else if (gameplay.indexY == 3)
    //    {
    //        if (gameplay.indexX == 0)
    //        {
    //            p30.Source = source;
    //        }
    //        else if (gameplay.indexX == 1)
    //        {
    //            p31.Source = source;
    //        }
    //        else if (gameplay.indexX == 2)
    //        {
    //            p32.Source = source;
    //        }
    //        else if (gameplay.indexX == 3)
    //        {
    //            p33.Source = source;
    //        }
    //        else
    //        {
    //            p34.Source = source;
    //        }
    //    }
    //    else
    //    {
    //        if (gameplay.indexX == 0)
    //        {
    //            p40.Source = source;
    //        }
    //        else if (gameplay.indexX == 1)
    //        {
    //            p41.Source = source;
    //        }
    //        else if (gameplay.indexX == 2)
    //        {
    //            p42.Source = source;
    //        }
    //        else if (gameplay.indexX == 3)
    //        {
    //            p43.Source = source;
    //        }
    //        else
    //        {
    //            p44.Source = source;
    //        }
    //    }
    //}
}
