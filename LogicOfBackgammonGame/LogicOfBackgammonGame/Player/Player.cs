using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicOfBackgammonGame
{
    public class Player : IPlayer
    {
        private int _NumberOfPossibleMoves;
        private readonly TheDice _dice;
        public readonly Board _board;
        public int _diceone { get; set; }
        public int _dicetwo { get; set; }
        public Colors WinnerColor { get; set; }

        Board IPlayer._board
        {
            get
            {
                if (_board == null) return new Board();
                else return _board;
            }
        }

        public Player()
        {
            _board = new Board();
            _dice = new TheDice();
            _NumberOfPossibleMoves = 0;
            _dicetwo = 0;
            _diceone = 0;
            WinnerColor = Colors.None;
        }

        /// <summary>
        /// this method sets who will begin (who gets the biggest number)
        /// </summary>
        /// <returns></returns>
        public bool WhoBegins(Colors CurrentColor)
        {
            _diceone = _dice.RollTheDice();
            _dicetwo = _dice.RollTheDice();

            if (_diceone < _dicetwo)
            {
                CurrentColor = Colors.Black;
                Rolling();
                return true;
            }
            else
            {
                CurrentColor = Colors.White;
                Rolling();
                return true;
            }
        }

        /// <summary>
        /// rolling the dice,
        /// if the player have equal number in both dices; 
        /// plays the numbers shown on the dice twice
        /// </summary>
        public void Rolling()
        {
            _diceone = _dice.RollTheDice();
            _dicetwo = _dice.RollTheDice();
            if (_diceone.Equals(_dicetwo))
                _NumberOfPossibleMoves = 4;
            else _NumberOfPossibleMoves = 2;
        }

        /// <summary>
        /// the method do the moves from position to position.
        /// and updates the possible moves left.
        /// </summary>
        /// <param name="from">from triangle</param>
        /// <param name="to">to triangle</param>
        /// <returns></returns>
        public bool MoveForBlackAndWhite(int from, int to, Colors CurrentColor)
        {
            if (ifValidMove(CurrentColor) == false) return false;

            bool ifMovehappend = WhiteAndBlackMove(from, to, CurrentColor);

            if (!ifMovehappend) return false;

            updateDices(Math.Abs(from - to));
            _NumberOfPossibleMoves--;
            UpdateifWeHaveWinner();
            return true;
        }

        public bool GotToEnd(int fromIndex, int toIndex, Colors CurrentColor)
        {
            switch (CurrentColor)
            {
                case Colors.Black:
                    if (toIndex < 0)
                    {
                        _board.board[fromIndex]++;
                        _board.BlackEnd++;
                        updateDices(Math.Abs(fromIndex - toIndex));
                        _NumberOfPossibleMoves--;
                        UpdateifWeHaveWinner();
                        return true;
                    }
                    break;
                case Colors.White:
                    if (toIndex > 23)
                    {
                        _board.board[fromIndex]--;
                        _board.WhiteEnd++;
                        updateDices(Math.Abs(fromIndex - toIndex));
                        _NumberOfPossibleMoves--;
                        UpdateifWeHaveWinner();
                        return true;
                    }
                    break;
            }
            return false;
        }

        public void updateDices(int posStep)
        {
            if (_NumberOfPossibleMoves > 0 && _NumberOfPossibleMoves <= 2)
            {
                if (posStep == _diceone)
                    _diceone = 0;
                else if (posStep == _dicetwo)
                {
                    _dicetwo = 0;
                }
            }
        }

        public bool WhiteAndBlackMove(int from, int to, Colors CurrentColor)
        {
            switch (CurrentColor)
            {
                case Colors.Black:
                    if (from - to == _diceone)
                        return _board.TryMove(from, to, CurrentColor);
                    if (from - to == _dicetwo)
                        return _board.TryMove(from, to, CurrentColor);
                    break;
                case Colors.White:
                    if (to - from == _diceone)
                        return _board.TryMove(from, to, CurrentColor);
                    if (to - from == _dicetwo)
                        return _board.TryMove(from, to, CurrentColor);
                    break;
            }
            return false;
        }

        /// <summary>
        /// helping method to the MoveForBlackAndWhite method,
        /// that checks if the move is illegal.
        /// </summary>
        /// <returns></returns>
        public bool ifValidMove(Colors CurrentColor)
        {
            if (_NumberOfPossibleMoves == 0)
            {
                return false;
            }
            if (CurrentColor.Equals(Colors.None))
                return false;
            if ((CurrentColor == Colors.White))
            {
                if (!CheckValidMoves(Colors.White))
                    return false;
            }
            if ((CurrentColor == Colors.Black))
            {
                if (!CheckValidMoves(Colors.Black))
                    return false;
            }
            return true;
        }

        public bool CheckValidMoves(Colors CurrentColor)
        {
            switch (CurrentColor)
            {
                case Colors.White:
                    for (var i = 0; i < 23; i++)
                        if (_board.board[i] > 0)
                        {
                            if (i + _diceone < 24
                                && _board.board[i + _diceone] > -2)
                                return true;
                            if (i + _dicetwo < 24 && _board.board[i + _dicetwo] > -2)
                                return true;
                        }
                    break;
                case Colors.Black:
                    for (var i = 23; i > 0; i--)
                        if (_board.board[i] > 0)
                        {
                            if (i - _diceone > 0 && _board.board[i - _diceone] < 2)
                                return true;
                            if (i - _dicetwo > 0 && _board.board[i - _dicetwo] < 2)
                                return true;
                        }
                    break;
            }
            return false;
        }

        /// <summary>
        /// helping method for the MoveForBalckAndWhiteMethod, 
        /// that checks if after every move we have a winner or not.
        /// and updates the winnerColor parameter
        /// </summary>
        private void UpdateifWeHaveWinner()
        {
            if (_board.BlackEnd == 15)
                WinnerColor = Colors.Black;
            if (_board.WhiteEnd == 15)
                WinnerColor = Colors.White;
        }
    }
}