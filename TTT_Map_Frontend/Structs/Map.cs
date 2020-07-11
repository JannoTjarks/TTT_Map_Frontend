﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTT_Map_Frontend.Structs
{
    public class Map
    {
        public Map(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }
        public string Name { get; }

        public override string ToString() => $"({Id}, {Name})";
    }
}
