using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_Life
{
    public class Tile
    {
        public bool isAlive;

        public Tile(bool live)
        {
            isAlive = live;
        }
    }
}
