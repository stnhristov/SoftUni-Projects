using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shark
{
    public struct Position
    {
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    public class Shark
    {
        public static Position[] directions = new Position[]
        {
            new Position(0, 1), //right
            new Position(0, -1), //left
            new Position(1, 0), //down
            new Position(-1, 0), //up
        };

        public static void SharkGenerator()
        {
            int direction = 0;
            Random numbersGeneration = new Random();
            Position food = new Position(numbersGeneration.Next(0, Console.WindowWidth),
                                         numbersGeneration.Next(0, Console.WindowHeight));//food@

            Position foodPersent = new Position(numbersGeneration.Next(0, Console.WindowWidth),
                                              numbersGeneration.Next(0, Console.WindowHeight));//food%



            Queue<Position> snakeElements = new Queue<Position>();
            for (int i = 0; i <= 5; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }


            while (true)
            {
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        direction = 1;
                    }
                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        direction = 0;
                    }
                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        direction = 2;
                    }
                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        direction = 3;
                    }
                }
                Position snakeHead = snakeElements.Last();
                Position nextDirection = directions[direction];
                Position snakeNewHead = new Position(snakeHead.row + nextDirection.row,
                                                     snakeHead.col + nextDirection.col);
                snakeElements.Enqueue(snakeNewHead);
                if (snakeNewHead.row < 0 ||
                    snakeNewHead.col < 0 ||
                    snakeNewHead.row >= Console.WindowHeight ||
                    snakeNewHead.col >= Console.WindowWidth)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(35, 10);
                    Console.WriteLine("GAME OVER!");
                    return;
                }

                if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                {
                    Console.SetCursorPosition(food.col, food.col);
                    Console.WriteLine("  ");
                    do
                    {
                        food = new Position(numbersGeneration.Next(0, Console.WindowWidth),
                                            numbersGeneration.Next(0, Console.WindowHeight));
                    }
                    while (snakeElements.Contains(food));
                }
                else
                {
                    snakeElements.Dequeue();
                }
                Console.Clear();

                foreach (Position position in snakeElements)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(position.col, position.row);
                    Console.Write("*");
                }

                //Console.ForegroundColor = ConsoleColor.Magenta;
                //Console.SetCursorPosition(food.row, food.col);//food @
                //Console.Write("@");
                //Console.SetCursorPosition(foodPersent.row, foodPersent.col);//food%
                //Console.Write("%");
                Thread.Sleep(150);

            }
        }

    }
}

