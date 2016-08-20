using LogicOfBackgammonGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public class Initializing
    {
        public readonly IPlayer _player;
        public readonly BoardDrawing _boardDrawing;
        public Initializing()
        {
            _player = new Player();
            _boardDrawing = new BoardDrawing();
        }

        /// <summary>
        /// this method changes player between black and white
        /// </summary>
        private Colors ChangeColor(Colors CurrentColor)
        {
            if (CurrentColor.Equals(Colors.White))
                return Colors.Black;
            if (CurrentColor.Equals(Colors.Black))
                return Colors.White;
            return Colors.None;
        }

        public void initializing(Colors CurrentColor)
        {
            Console.WriteLine("press enter to see who begins in randomly way");
            _player.WhoBegins(CurrentColor);
            Console.ReadLine();
        }


        public void Play(Colors CurrentColor)
        {
            while (_player.WinnerColor.Equals(Colors.None))
            {
                Console.Clear();
                _boardDrawing.DrawBoard(_player);
                _player.Rolling();

                while (_player.ifValidMove(CurrentColor))
                {
                    Console.Clear();
                    _boardDrawing.DrawBoard(_player);
                    Console.WriteLine($"Black's end stones : {_player._board.BlackEnd}");
                    Console.WriteLine($"White's end stones : {_player._board.WhiteEnd}");
                    Console.WriteLine($"{CurrentColor}'s Turn");
                    Console.WriteLine($"{_player._diceone} {_player._dicetwo}");
                    Console.Write("move from: ");
                    var from = Console.ReadLine();
                    var fromIndex = 0;
                    if (int.TryParse(from, out fromIndex))
                    {
                        Console.Write("move to: ");
                        var to = Console.ReadLine();
                        var toIndex = 0;
                        if (int.TryParse(to, out toIndex))
                        {
                            if (!_player.GotToEnd(fromIndex, toIndex , CurrentColor))
                            {
                                Console.WriteLine(_player.MoveForBlackAndWhite(fromIndex, toIndex, CurrentColor) ? "GoodMove." : "BadMove, You can try one more time.");
                                _boardDrawing.DrawBoard(_player);
                                Console.Read();
                            }
                        }
                    }
                }
                CurrentColor = ChangeColor(CurrentColor);
            }
            Console.WriteLine($"{_player.WinnerColor} Wins :) ");
        }
    }
}