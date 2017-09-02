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

            foreach (var field in currentInfoAboutFields)
            {
                if (field.Mark == _currentPlayer)
                {
                    counter++;
                }
                else
                {
                    counter=0;
                }

                if (counter==_fieldsToWin)
                {
                    return true;
                }
                
            }

            return false;

            var allMarks = currentInfoAboutFields.FindAll(x => x.Mark == _currentPlayer);

        }
    }
}
