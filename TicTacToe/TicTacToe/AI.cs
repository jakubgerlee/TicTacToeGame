using System;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class AI
    {
        private static int _counter = 1;
        private bool _humanIsCloseToWin = false;
        private bool _filedIsFilled = false;
        private string _field;
        private int _boardSize = 0;

        public string Move(int boardSize, int filedsToWin)
        {
            _boardSize = boardSize;

            var board = new Board();
            var symbolFields = board.GetCurrentInfoAboutFields();

            var field = new Field();

            if (_counter == 1)
            {
                do
                {
                    var rnd = new Random(DateTime.Now.Millisecond);
                    var rnd1 = new Random(DateTime.Now.Second);

                    int index1 = rnd.Next(1, _boardSize);
                    int index2 = rnd1.Next(1, _boardSize);

                    field = symbolFields.First(x => x.IndexOne == index1 || x.IndexTwo == index2);
                } while (field.FieldIsEmpty == false);

                _counter++;

                return field.SymbolField;
            }
            
            NextMove(filedsToWin);

            if (_field != null)
            {
                return _field;
            }



            return field.SymbolField;
        }

        private void NextMove(int fieldsToWin)
        {
            _filedIsFilled = false;
            _humanIsCloseToWin = false;
            CheckItIsCloseToWinHorizontal(fieldsToWin);
            if (!_filedIsFilled)
            {
                CheckItIsCloseToWinVertical(fieldsToWin);
            }

            if (_field == null)
            {
                var board = new Board();
                var findEmptyField = board.GetCurrentInfoAboutFields();
                var field = findEmptyField.FirstOrDefault(x=> x.FieldIsEmpty);
                _field = field.SymbolField;
            }
        }

        public bool CheckItIsCloseToWinHorizontal( int fieldsToWin)//nie pozwala wygrac w horyzoncie
        {
            var board = new Board();
            var currentInfoAboutFields = board.GetCurrentInfoAboutFields();
            int counterLoop = 0;
            int counterSymbolInRow = 0;
            
            foreach (var field in currentInfoAboutFields)
            {
                if (counterLoop == _boardSize)
                {
                    counterSymbolInRow = 0;
                    counterLoop = 0;
                }

                if (field.Mark == "x")
                {
                    counterSymbolInRow++;
                }
                else
                {
                    counterSymbolInRow = 0;
                }

                if (fieldsToWin < _boardSize)
                {
                    if (counterSymbolInRow == fieldsToWin - 2)
                    {
                        _humanIsCloseToWin = true;
                        PreventHumanWinningHorizontal(field, counterSymbolInRow);

                    }
                }
                else
                {
                    if (counterSymbolInRow == fieldsToWin - 1)
                    {
                        _humanIsCloseToWin = true;
                        PreventHumanWinningHorizontal(field, counterSymbolInRow);

                    }
                }

                counterLoop++;

                if (_humanIsCloseToWin)
                {
                    return false;
                }
            }

            return false;
        }

        private void PreventHumanWinningHorizontal(Field field1, int counterSymbolInRow)
        {
            var board = new Board();

            var currentInfoAboutFields = board.GetCurrentInfoAboutFields();

            var checkFiledOnRight= currentInfoAboutFields.FirstOrDefault(x => x.IndexOne == field1.IndexOne && x.IndexTwo == field1.IndexTwo+1); //sprawdzenie czy symbolu po prawej

            if (checkFiledOnRight == null || checkFiledOnRight.Mark=="x")//jesli pusty, wtedy wyszedł poza zakres, i musi sprawdzić z lewej strony
            {
                var checkFiledOnLeft = currentInfoAboutFields
                    .FirstOrDefault(x => x.IndexOne == field1.IndexOne && x.IndexTwo == field1.IndexTwo - (counterSymbolInRow));//sprawdzenie czy symbolu po lewej

                if (checkFiledOnLeft == null)
                {
                }
                else if(checkFiledOnLeft.FieldIsEmpty == true)
                {
                    _field = checkFiledOnLeft.SymbolField;
                    _filedIsFilled = true;
                }

            }
            else if(checkFiledOnRight.FieldIsEmpty == false)
            {
            }
            else if (checkFiledOnRight.FieldIsEmpty == true )
            {
                _field = checkFiledOnRight.SymbolField;
                _filedIsFilled = true;
            }

        }

        public bool CheckItIsCloseToWinVertical(int fieldsToWin)
        {
            _humanIsCloseToWin = false;
            var board = new Board();
            var currentInfoAboutFields = board.GetCurrentInfoAboutFields();
            var counterSymbolInRow = 0;
            for (int i = 1; i <= _boardSize; i++)
            {
                foreach (var field in currentInfoAboutFields)
                {
                    if (field.IndexTwo == i)
                    {
                        if (field.Mark == "x")
                        {
                            counterSymbolInRow++;

                            if (fieldsToWin < _boardSize)
                            {
                                if (counterSymbolInRow == fieldsToWin - 2)
                                {
                                    _humanIsCloseToWin = true;
                                    PreventHumanWinningVertical(field, counterSymbolInRow);

                                }
                            }
                            else
                            {
                                if (counterSymbolInRow == fieldsToWin - 1)
                                {
                                    _humanIsCloseToWin = true;
                                    PreventHumanWinningVertical(field, counterSymbolInRow);

                                }
                            }
                        }
                        else
                        {
                            counterSymbolInRow = 0;
                            _field = null;
                            
                        }
                    }
                    if (_humanIsCloseToWin)
                    {
                        return false;
                    }

                }
                counterSymbolInRow = 0;
            }
            return false;
        }

        private void PreventHumanWinningVertical(Field field1, int counterSymbolInRow)
        {
            var board = new Board();
            var currentInfoAboutFields = board.GetCurrentInfoAboutFields();

            var findField = currentInfoAboutFields
                .FirstOrDefault(x => x.IndexOne == field1.IndexOne + 1 && x.IndexTwo == field1.IndexTwo); //sprawdzenie pola po powtarzającej się sekwencji (na dole)

            if (findField == null)//jesli pusty, wtedy wyszedł poza zakres, i musi sprawdzić od góry
            {
                findField = currentInfoAboutFields
                    .FirstOrDefault(x => x.IndexOne == field1.IndexTwo-counterSymbolInRow && x.IndexTwo == field1.IndexTwo);//sprawdzenie pola przed powtarzającą się sekwencją (od góry)

                if (findField == null)
                {

                }
                else if (findField.FieldIsEmpty == true)
                {
                    _field = findField.SymbolField;
                    _filedIsFilled = true;
                }

            }
            else if (findField.FieldIsEmpty == false)
            {
                findField = currentInfoAboutFields
                    .FirstOrDefault(x => x.IndexOne == field1.IndexOne + 2 && x.IndexTwo == field1.IndexTwo);
                if (findField.FieldIsEmpty == true)
                {
                    _field = findField.SymbolField;
                    _filedIsFilled = true;
                }
            }
            else if (findField.FieldIsEmpty == true)
            {
                _field = findField.SymbolField;
                _filedIsFilled = true;
            }

        }
    }
}
