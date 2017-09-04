using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        private string[,] _tab;
        private int _boardSize;
        private string _currentPlayer = "x"; //x - starting
        private bool _gameFinished = false;
        private int _fieldsToWin;
        private bool _gameWithAI = false;

        public Game(int boardSize, string[,] tab, int fieldsToWin)
        {
            _boardSize = boardSize;
            _tab = tab;
            _fieldsToWin = fieldsToWin;
        }

        public Game()
        {
            
        }

        public void GameLoop(bool gameWithAI)
        {
            _gameWithAI = gameWithAI;

            var board = new Board(_boardSize);

            while (!_gameFinished)
            {
                board.DisplayBoard(_tab);//display board

                Turn();//do round

                if (_gameFinished)//check if someone win
                {
                    Console.Clear();
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
            string step;

            if (_gameWithAI && _currentPlayer == "o")
            {
                var computer = new AI();
                step = computer.Move(_boardSize, _fieldsToWin);
            }
            else
            {
                 step = ConsoleReadHelper.GetSymbolField(_currentPlayer, "Type next step: ");
            }


            var index = currentInfoAboutFields.FirstOrDefault(x => x.SymbolField == step);

            _tab[index.IndexOne, index.IndexTwo] = _currentPlayer; //mark symbol on board
            
            index.FieldIsEmpty = false;
            index.Mark = _currentPlayer;

            
            var ifWinner = CheckSomeoneWin();
            var ifDraw = CheckIsItDraw();

            if (ifWinner)
            {
                Console.Clear();
                board.DisplayBoard(_tab);//display board
                Console.WriteLine($"\n\n\t\tWinner is player: {_currentPlayer.ToUpper()}".ToUpper() +
                                  $"\n\n\n\n -----type one key on keyboard, to get back to main menu------");
                Console.ReadKey();
                _gameFinished = true;
                return;
            }

            if (ifDraw)
            {
                board.DisplayBoard(_tab);//display board
                Console.WriteLine($"THERE IS NO WINNER... IT'S DRAW " +
                                  $"\n\n\n\n -----tap any key on keyboard, to get back to main menu------");
                Console.ReadKey();
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

            if (CheckWinner.CheckWinnerHorizontal() 
                || CheckWinner.CheckWinnerVertical()
                || CheckWinner.CheckWinnerSlanAtFront() 
                || CheckWinner.CheckWinnerSlantAtBack())
            {
                return true;
            }

            return false;
        }

        private bool CheckIsItDraw()
        {
            var winner = new Winner(_boardSize, _currentPlayer, _fieldsToWin);
            if (winner.IsDraw())
            {
                var board = new Board();
                board.DisplayBoard(_tab);//display board
                Console.WriteLine($"THERE IS NO WINNER... IT'S DRAW " +
                                  $"\n\n\n\n -----tap any key on keyboard, to get back to main menu------");
                _gameFinished = true;

                return true;
            }
            return false;
        }

    }
}
 