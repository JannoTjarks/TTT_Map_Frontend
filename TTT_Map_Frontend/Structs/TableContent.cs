﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTT_Map_Frontend.Structs
{
    public class TableContent
    {
        public TableContent(string name, int rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name { get; }
        public int Rating { get; }

        public override string ToString() => $"({Name}, {Rating})";
    }
}
