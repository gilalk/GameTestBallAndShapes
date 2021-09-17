using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    public class TheGame
    {
        static Board gameBoard;
        static int numOfShapes = 4;
        static int points = 0;

        public static void StartGame()
        {
            while (numOfShapes < 15)
            {
                gameBoard = new Board(80, 25);
                try
                {
                    gameBoard.PrintShapes(numOfShapes);
                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
                Console.BackgroundColor = ConsoleColor.Black;
                gameBoard.PrintPoint();
                while (true)
                {
                    try
                    {
                        gameBoard.MovePoint();
                        points++;
                        Console.SetCursorPosition(34, 25);
                        Console.Write($"POINTS: {points}");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        numOfShapes++;
                        Console.Clear();
                        break;
                    }
                }
            }

            Console.SetCursorPosition(34, 12);
            Console.WriteLine("GAME OVER");
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("Play Again? (Y/N)");
            Console.SetCursorPosition(36, 14);
            string ans = Console.ReadLine();
            if (ans == "y" || ans == "Y")
            {
                gameBoard.tries = 0;
                numOfShapes = 4;
                gameBoard.ClearBoard();
                Console.Clear();
                StartGame();
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(34, 12);
                Console.WriteLine("Good Bye!");
            }
        }
    }
}
