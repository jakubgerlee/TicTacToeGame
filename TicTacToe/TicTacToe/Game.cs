using System;
using System.Threading;

namespace TicTacToe
{
    public class Game
    {
        private string[,] _tab;
        private static int _boardSize;
        private string _player = "x"; //x - starting
        private bool _turn = false; //x -starting
        private bool _gameFinished = false;

        public Game(int boardSize ,string[,] tab)
        {
            _boardSize = boardSize;
            _tab = tab;

        }

        public void GameLoop()
        {
            var board = new Board(_boardSize);

            while (!_gameFinished)
            {
                board.DisplayBoard(_tab);//displaying board
                turn();
                Console.Clear();
            }
        }

        public void turn()
        {
            //TODO copy+paste to ConsoleReadHelpers later
            if (_turn)
            {
                Console.WriteLine($"Turn: [{_player}]" +
                                  $"\n Type next step: ");
                var step = Console.ReadLine();
                _player = "x";
                _turn = false;

            }
            else
            {
                Console.WriteLine($"Turn: [{_player}]" +
                                  $"\n Type next step: ");
                var step = Console.ReadLine();
                _player = "o";
                _turn = true;
            }

        }




    }
}
