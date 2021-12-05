using System;
using System.Timers;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    class Game
    {
        public string[] Arrows1 = { "U", "UR", "R", "DR", "D", "DL", "L", "LU" };
        public Dictionary<string,int> Arrows = new Dictionary<string, int>() { { "U",-90 }, { "UR",-45 }, { "R",0 }, { "DR",45 }, { "D",90 }, { "DL",135 }, { "L",180 }, { "LU",225} };
        public int[,] Board = new int[5, 5];
        public int indexX = 2;
        public int indexY = 2;
        public static int stage = 1;
        public int score = 0;
        public static int count { get; set; }
        public static int speed { set; get; }
    }
}
