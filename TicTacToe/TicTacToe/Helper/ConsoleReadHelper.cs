using System;
using System.IO;
using System.Threading;

namespace TicTacToe
{
    public class ConsoleReadHelper
    {
        public static App.CommandTypes GetCommnadType(string message)
        {
            App.CommandTypes commandType;
            Console.Write(
                           " 1. GameForTwo, " +
                           " 2. GameWithComputer, " +
                           " 3. Exit " +
                           "\n\n" + message);

            while (!Enum.TryParse(Console.ReadLine(), out commandType))
            {
                Console.Clear();
                Console.WriteLine("Typed command doesn't exists...");
                Console.Write(
                    " 1. GameForTwo, " +
                    " 2. GameWithComputer, " +
                    " 3. Exit " +
                    "\n\n" + message);
            }

            return commandType;
        }//get command from menu 

        public static int GetBoardSize(string message)
        {
            var number = 0;
            Console.WriteLine(message);
            
            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("wrong number");
                Thread.Sleep(500);
                Console.Clear();
            }

            while (number==0)
            {
                Console.WriteLine("Typed command doesn't exists...\n");
                Console.Write(
                    " 1. 3 - 3x3 \n" +
                    " 2. 4 - 4x4 \n" +
                    " 3. 5 - 5x5 \n" +
                    " 4. 6 - 6x6 \n" +
                    " 5. 7 - 7x7 \n" +
                    " 6. 8 - 8x8 \n" +
                    " 7. 9 - 9x9 \n" +
                    " 8. 10 - 10x10 \n" +
                    "\n\n");

                try
                {
                    Console.WriteLine(message);
                    number = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("wrong number");
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }
            Console.Clear();

            return number;
        }

    }
}
