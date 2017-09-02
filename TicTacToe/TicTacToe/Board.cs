using System;

namespace TicTacToe
{
    public class Board
    {
        private readonly int _boardSize;
        private char _letter = 'A';

        public Board(int boardSize)
        {
            _boardSize = boardSize;
        }

        public string[,] CreateBoard()
        {
            string[,] boardTab = new string[_boardSize + 1, _boardSize + 1]; //dodajac ramki
            boardTab = CreateFrame(boardTab);
            boardTab = FillWhiteSpaceInEmptyFields(boardTab);

            return boardTab;
        }

        public string[,] CreateFrame(string[,] boardTab)
        {
            boardTab[0, 0] = "#";

            for (int i = 1; i <= _boardSize; i++)
            {
                boardTab[0, i] = i.ToString();

            }//1,2,3,4...

            for (int i = 0; i <= _boardSize; i++)
            {
                boardTab[i, 0] = _letter.ToString();

                ++_letter;
                
            }//A,B,C,D...

            return boardTab;
        }

        public string[,] FillWhiteSpaceInEmptyFields(string[,] boardTab)
        {
            for (int i = 1; i <=_boardSize; i++)
            {
                for (int j = 1; j <= _boardSize; j++)
                {
                    boardTab[j, i] = " ";

                }//" "...

            }
            return boardTab;
        }

        public void DisplayBoard(string[,] boardTab)
        {
            string separator = "--";

            for (int i = 0; i < boardTab.GetLength(0); i++)
            {
                for (int j = 0; j <= _boardSize; j++)
                {
                    Console.Write(boardTab[i, j] + "|" );
                }//x|o|x|...

                Console.WriteLine();

                for (int j = 0; j <= _boardSize; j++)
                {
                    Console.Write(separator);
                }// ----...
                Console.WriteLine();
            }

            Console.Read();
        }

    }
}
