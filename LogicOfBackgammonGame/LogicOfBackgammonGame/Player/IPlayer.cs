using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicOfBackgammonGame
{
    public interface IPlayer
    {
        Board _board { get; }
        int _diceone { get; set; }
        int _dicetwo { get; set; }
        Colors WinnerColor { get; set; }

        bool WhoBegins(Colors CurrentColor);
        void Rolling();
        bool MoveForBlackAndWhite(int from, int to, Colors CurrentColor);
        bool GotToEnd(int fromIndex, int toIndex, Colors CurrentColor);
        void updateDices(int posStep);
        bool WhiteAndBlackMove(int from, int to, Colors CurrentColor);
        bool ifValidMove(Colors CurrentColor);
        bool CheckValidMoves(Colors CurrentColor);
       // void UpdateifWeHaveWinner();
    }
}