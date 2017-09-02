using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class App
    {
        private static int _boardSize;
        private static int _fieldsToWin;
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
            while (true)
            {
                Introductions();

                _boardSize = ConsoleReadHelper.GetBoardSize("Type board size (3-10)"); //NIE MOZE BYC PUSTY
                _fieldsToWin = ConsoleReadHelper.GetBoardSize($"How many symbols next each other do you need to win ?" +
                                                              $"[Min 3 Max {_boardSize}] type:  "); // DODAJ SPRAWDZENIE CZY JEST GIT

                switch (ConsoleReadHelper.GetCommnadType("Type command: "))
                {
                    case CommandTypes.GameForTwo:
                        _gameWithAI = false;
                        GameLoop();
                        break;
                    case CommandTypes.GameWithComputer:
                        _gameWithAI = true;
                        break;
                    case CommandTypes.Exit:
                        Environment.Exit(0);
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

        public void GameLoop()
        {
            var board = new Board(_boardSize);
            _boardToPlay = board.CreateBoard();

            if (!_gameWithAI)
            {
                var game = new Game(_boardSize, _boardToPlay, _fieldsToWin);
                game.GameLoop();
            } //playwithyourself
            else
            {
            } //playwithcomputer

        }
    }
}
