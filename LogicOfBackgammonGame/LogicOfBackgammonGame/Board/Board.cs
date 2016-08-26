using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicOfBackgammonGame
{
    public class Board
    {
        public int[] board { get; }
        public int WhiteBar { get; set; }
        public int BlackBar { get; set; }

        public int WhiteEnd { get; set; }
        public int BlackEnd { get; set; }


        public Board()
        {
            board = new[] {
                2, 0, 0, 0, 0, -5, 0, -3, 0, 0, 0, 5, // Down
                -5, 0, 0, 0, 3, 0, 5, 0, 0, 0, 0, -2, // Up
            };
            WhiteBar = BlackBar = 0;
            WhiteEnd = BlackEnd = 0;
        }

        /// <summary>
        /// this method gets the board to print it (with positive numbers),
        /// because we used a negative numbers for the black color.
        /// The Event Used Here ! 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BoardTriangle> GetBoardForPrint()
        {
            return board.Select(i =>
            {
                if (i > 0)
                    return new BoardTriangle(i, Colors.White);
                if (i < 0)
                    return new BoardTriangle(Math.Abs(i), Colors.Black);
                else
                    return new BoardTriangle(0, Colors.None);
            });
        }

        public bool TryMove(int from, int to, Colors currentColor)
        {
            switch (currentColor)
            {
                case Colors.Black:
                    if (board[from] < 0)
                        if (board[to] <= 0)
                        {
                            board[to]--;
                            board[from]++;
                            return true;
                        }
                    break;
                case Colors.White:
                    if (board[from] > 0)
                        if (board[to] >= 0)
                        {
                            board[to]++;
                            board[from]--;
                            return true;
                        }
                    break;
            }
            return false;
        }
    }
}
