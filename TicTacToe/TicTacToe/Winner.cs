using System.Diagnostics;
using System.Threading;

namespace TicTacToe
{
    public class Winner
    {
        private static int _boardSize;
        private string _currentPlayer = "x"; //x - starting
        private int _fieldsToWin;
        private int counter;
        private char letter = 'A';

        public Winner(int boardSize, string currentPlayer, int fieldsToWin)
        {
            _boardSize = boardSize;
            _currentPlayer = currentPlayer;
            _fieldsToWin = fieldsToWin;
        }

        public bool CheckWinnerHorizontal()
        {
            var board = new Board();
            var currentInfoAboutFields = board.GetCurrentInfoAboutFields();
            int counterLoop = 0;
            foreach (var field in currentInfoAboutFields)
            {
                
                if (counterLoop ==_boardSize)
                {
                    counter = 0;
                    counterLoop = 0;
                }
                
                    if (field.Mark == _currentPlayer)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }

                    if (counter == _fieldsToWin)
                    {
                        return true;
                    }
                    counterLoop++;
            }

            return false;
        }

        public bool CheckWinnerVertical()
        {
            var board = new Board();
            var currentInfoAboutFields = board.GetCurrentInfoAboutFields();
            
            for (int i = 1; i <=_boardSize; i++)
            {
                foreach (var field in currentInfoAboutFields)
                {
                    if (field.IndexTwo == i)
                    {
                        if (field.Mark == _currentPlayer)
                        {
                            counter++;
                            if (counter==_fieldsToWin)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            counter = 0;
                        }
                    }

                }
                counter = 0;
            }


            return false;
        }

        public bool CheckWinnerSlanAtFront()
        {
            //PART1
            var board = new Board();
            var currentInfoAboutFields = board.GetCurrentInfoAboutFields();
            int counterIndexOne = 1;
            int counterIndexTwo = 1;

            for (int i = 1 ; i<=_boardSize ; i++)
            {
                
                foreach (var field in currentInfoAboutFields)
                {
                    if (field.IndexOne == counterIndexOne && field.IndexTwo == counterIndexTwo)
                    {
                        counterIndexOne++;
                        counterIndexTwo++;

                        if (field.Mark == _currentPlayer)
                        {
                            counter++;

                            if (counter==_fieldsToWin)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            counter = 0;
                        }
                    }
                }
                counter = 0;
                counterIndexOne = 1;
                counterIndexTwo = i;
            }// checking form middle, to upper

            counterIndexOne = 1;
            counterIndexTwo = 1;
            counter = 0;

            //PART2
            for (int i = 1; i <= _boardSize; i++)
            {
                foreach (var field in currentInfoAboutFields)
                {
                    if (field.IndexOne == counterIndexOne && field.IndexTwo == counterIndexTwo)
                    {
                        counterIndexOne++;
                        counterIndexTwo++;

                        if (field.Mark == _currentPlayer)
                        {
                            counter++;

                            if (counter == _fieldsToWin)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            counter = 0;
                        }
                    }
                }
                counter = 0;
                counterIndexOne = i;
                counterIndexTwo = 1;
            }// checking form middle, to lower


            return false;
        }

        public bool CheckWinnerSlantAtBack()
        {
            //PART1
            var board = new Board();
            var currentInfoAboutFields = board.GetCurrentInfoAboutFields();
            int counterIndexOne = 1;
            int counterIndexTwo = _boardSize;

            for (int i = _boardSize; i >= 1; i--)
            {
                foreach (var field in currentInfoAboutFields)
                {
                    if (field.IndexOne == counterIndexOne && field.IndexTwo == counterIndexTwo)
                    {
                        counterIndexOne++;
                        counterIndexTwo--;

                        if (field.Mark == _currentPlayer)
                        {
                            counter++;

                            if (counter == _fieldsToWin)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            counter = 0;
                        }
                    }
                }
                counter = 0;
                counterIndexOne = 1;
                counterIndexTwo = i;
            }// checking form middle, to upper

            counterIndexOne = 2;
            counterIndexTwo = _boardSize;
            counter = 0;

            for (int i = _boardSize; i >= 1; i--)
            {
                foreach (var field in currentInfoAboutFields)
                {
                    if (field.IndexOne == counterIndexOne && field.IndexTwo == counterIndexTwo)
                    {
                        counterIndexOne++;
                        counterIndexTwo--;

                        if (field.Mark == _currentPlayer)
                        {
                            counter++;

                            if (counter == _fieldsToWin)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            counter = 0;
                        }
                    }
                }
                counter = 0;
                counterIndexOne = i;
                counterIndexTwo = 6;
            }// checking form middle, to upper



            return false;
        }



    }
}
