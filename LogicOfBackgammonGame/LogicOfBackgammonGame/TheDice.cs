using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicOfBackgammonGame
{
    public class TheDice
    {
        public Random randomNumber;

        public TheDice()
        {
            randomNumber = new Random();
            randomNumber.Next(1, 7);
        }

        public int RollTheDice()
        {
            return randomNumber.Next(1, 7);
        }
    }
}
