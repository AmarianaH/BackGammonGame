using System;
using System.Linq;
using LogicOfBackgammonGame;

namespace ConsoleApplication1
{
    public class Program
    {
        internal static Colors CurrentColor { get; set; }
        
        static void Main(string[] args)
        {
            Initializing p = new Initializing();
            p.initializing(CurrentColor);
            p.Play(CurrentColor);
        }

    }
}
