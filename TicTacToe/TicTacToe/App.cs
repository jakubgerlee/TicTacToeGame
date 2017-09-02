using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class App
    {
        private static bool _exit = false;
        private static int _boardSize;
        private string[,] _boardToPlay;
        private bool _gameWithAI = false;

        public enum CommandTypes
        {
            GameForTwo,
            GameWithComputer,
            Exit
        }


        public void Menu()
        {
            Introductions();

            _boardSize = ConsoleReadHelper.GetBoardSize("Type board size (3-10)");

            while (!_exit)
            {
                switch (ConsoleReadHelper.GetCommnadType("Type command: "))
                {
                    case CommandTypes.GameForTwo:
                        _gameWithAI = false;
                        GameStart();
                        break;
                    case CommandTypes.GameWithComputer:
                        _gameWithAI = true;
                        break;
                    case CommandTypes.Exit:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Introductions()
        {
            Console.WriteLine("\t\t'TIC TAC TOE' - GAME !\n\n");
        }

        public void GameStart()
        {
            var board = new Board(_boardSize);
            _boardToPlay = board.CreateBoard();
            board.DisplayBoard(_boardToPlay);

            if (_gameWithAI)
            {
                //playwithcomputer
            }
            else
            {
                //playwithyourself
            }
        }
    }
}
