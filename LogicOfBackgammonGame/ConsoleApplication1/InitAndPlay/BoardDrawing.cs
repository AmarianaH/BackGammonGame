using LogicOfBackgammonGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class BoardDrawing
    {
        public void DrawBoard(IPlayer _player)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Green;
            var board = _player._board.GetBoardForPrint().ToArray();
            int[,] a = new int[2, 12];
            int j = 0;

            for (int i = 12; i <= 23; i++)
            {
                a[0, j] = i;
                j++;
            }

            j = 0;
            for (int i = 12; i <= 23; i++)
            {
                a[1, j] = board[i]._numberOfStones;
                j++;
            }


            for (int i = 0; i <= 11; i++)
            {
                if (i == 6) Console.Write(" | ");
                Console.Write(String.Format($"{a[0, i],-5}"));
            }

            Console.WriteLine();
            j = 12;
            for (int i = 0; i <= 11; i++)
            {
                if (i == 6) Console.Write(" | ");

                if (board[j]._triangleColor == Colors.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(String.Format($"{a[1, i],-5}"));
                }
                else if (board[j]._triangleColor == Colors.White)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(String.Format($"{a[1, i],-5}"));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(String.Format($"{a[1, i],-5}"));
                }
                j++;
            }
            Console.WriteLine();
            Console.Write("_______________________________________________________________");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            DrawDownBoard(_player);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DrawDownBoard(IPlayer _player)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Green;
            var board = _player._board.GetBoardForPrint().ToArray();

            int[,] a = new int[2, 12];
            int j = 0;

            for (int i = 11; i >= 0; i--)
            {
                a[0, j] = i;
                j++;
            }

            j = 0;
            for (int i = 0; i <= 11; i++)
            {
                a[1, j] = board[i]._numberOfStones;
                j++;
            }



            Console.WriteLine();
            for (int i = 11; i >= 0; i--)
            {
                if (i == 5) Console.Write(" | ");
                if (board[i]._triangleColor== Colors.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(String.Format($"{a[1, i],-5}"));
                }
                else if (board[i]._triangleColor == Colors.White)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(String.Format($"{a[1, i],-5}"));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(String.Format($"{a[1, i],-5}"));
                }
            }

            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();

            for (int i = 0; i <= 11; i++)
            {
                if (i == 6) Console.Write(" | ");
                Console.Write(String.Format($"{a[0, i],-5}"));
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
