using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private readonly int _boardSize;
        private char _letterFrame = 'A';
        private char _letterIndexSymbol = 'A';
        private int _counter = 0;
        public static Dictionary<string, Index> IndexDictionary = new Dictionary<string, Index>();

        public static List<Field> CurrentInfoAboutFields = new List<Field>();


        public Board() { }

        public Board(int boardSize)
        {
            _boardSize = boardSize;
        }

        public string[,] CreateBoard()
        {
            FillListWithInformationField();

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

            for (int i = 1; i <= _boardSize; i++)
            {
                boardTab[i, 0] = _letterFrame.ToString();

                ++_letterFrame;
                
            }//A,B,C,D...

            return boardTab;
        }

        public string[,] FillWhiteSpaceInEmptyFields(string[,] boardTab)
        {
            for (int i = 1; i <=_boardSize; i++)
            {
                for (int j = 1; j <= _boardSize; j++)
                {
                    boardTab[i, j] = " ";
                    _counter++; //iterate number

                    FillDictionary(i, j);

                }
                _letterIndexSymbol++; //iterate A

            }//" "...
            return boardTab;
        }

        private void FillDictionary(int i, int j)
        {
            var index = new Index(i, j);

            if (_counter == _boardSize)
            {
                string symbolName = _letterIndexSymbol.ToString() + _counter;
                AddIndexToSymbolNameInInformationAboutFields(symbolName, index);

                _counter = 0;
            }
            else
            {
                string symbolName = _letterIndexSymbol.ToString() + _counter;
                AddIndexToSymbolNameInInformationAboutFields(symbolName, index);
            }

        }

        private void AddIndexToSymbolNameInInformationAboutFields(string symbolName, Index index)
        {
            var field = CurrentInfoAboutFields.FirstOrDefault(x => x.SymbolField == symbolName);

            field.IndexOne = index.IndexOne;
            field.IndexTwo = index.IndexTwo;

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
        }

        private  void FillListWithInformationField()
        {
            int counter = 1;
            char letter = 'A';

            for (int i = 1; i <= _boardSize; i++)
            {
                for (int j = 1; j <= _boardSize; j++)
                {
                    var field = new Field();

                    field.SymbolField = letter.ToString() + counter;
                    field.FieldIsEmpty = true;
                    CurrentInfoAboutFields.Add(field);

                    if (counter == _boardSize)
                    {
                        counter = 0;
                    }
                    counter++;

                }
                letter++;
            }
        }

        public List<Field> GetCurrentInfoAboutFields()
        {
            return CurrentInfoAboutFields;
        }
    }
}
