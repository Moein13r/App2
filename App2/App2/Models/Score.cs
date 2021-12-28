﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace App2.Models
{
    class Score
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        [Indexed]
        public string name { get; set; }
        public int score { get; set; }
        public int state { get; set; }
        
    }
}
