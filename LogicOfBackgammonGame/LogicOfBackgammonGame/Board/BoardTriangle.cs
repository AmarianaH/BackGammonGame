using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicOfBackgammonGame
{   
    public class BoardTriangle
    {
        public Colors _triangleColor { get; }
        public int _numberOfStones { get; }

        internal BoardTriangle(int numOfStones , Colors color)
        {
            _numberOfStones = numOfStones;
            _triangleColor = color;
        }
    }
}
