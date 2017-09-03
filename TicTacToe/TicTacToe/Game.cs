using System;
using System.Linq;
using System.Threading;

namespace TicTacToe
{
    public class Game
    {
        private string[,] _tab;
        private int _boardSize;
        private string _currentPlayer = "x"; //x - starting
        private bool _gameFinished = false;
        private int _fieldsToWin;

        public Game(int boardSize, string[,] tab, int fieldsToWin)
        {
            _boardSize = boardSize;
            _tab = tab;
            _fieldsToWin = fieldsToWin;
        }

        public Game()
        {
            
        }

        public void GameLoop()
        {
            var board = new Board(_boardSize);

            while (!_gameFinished)
            {
                board.DisplayBoard(_tab);//display board

                Turn();//do round

                if (_gameFinished)//check if someone win
                {
                    _tab = null;
                    _boardSize = 0;
                    _currentPlayer = "x";
                    _gameFinished = false;
                    _fieldsToWin = 0;
                    board.CleanGame();
                    return;
                }

                Console.Clear();
            }


        }

        public void Turn()
        {
            var board = new Board(_boardSize);
            var currentInfoAboutFields = board.GetCurrentInfoAboutFields();

            var step = ConsoleReadHelper.GetSymbolField( _currentPlayer,"Type next step: ");

            var index = currentInfoAboutFields.FirstOrDefault(x => x.SymbolField == step);
            _tab[index.IndexOne, index.IndexTwo] = _currentPlayer; //mark symbol on board
            
            index.FieldIsEmpty = false;
            index.Mark = _currentPlayer;
            var ifWinner = CheckSomeoneWin();

            if (ifWinner)
            {
                Console.WriteLine($"Winner is player: {_currentPlayer.ToUpper()}");
                _gameFinished = true;
                return;
            }

            if (_currentPlayer == "x")
            {
                _currentPlayer = "o";
            }
            else
            {
                _currentPlayer = "x";
            }
            
        }

        private bool CheckSomeoneWin()
        {
            var CheckWinner = new Winner(_boardSize, _currentPlayer, _fieldsToWin);

            if (CheckWinner.CheckWinnerHorizontal())
            {
                return true;
            }


            return false;
        }

    }
}
 