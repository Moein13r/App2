using System;
using System.Timers;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    class Game
    {
        public string[] Arrows1 = { "U", "UR", "R", "DR", "D", "DL", "L", "LU" };
        public Dictionary<string, double> Arrows = new Dictionary<string, double>() { { "U",-90 }, { "UR",-45 }, { "R",0 }, { "DR",45 }, { "D",90 }, { "DL",135 }, { "L",180 }, { "LU",225} };
        public int[,] Board = new int[5, 5];
        public int indexX = 2;
        public int indexY = 2;
    }
}
