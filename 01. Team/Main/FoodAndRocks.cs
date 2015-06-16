using System;
using System.Collections.Generic;
using System.Threading;

class FoodAndRocks
{
    // fields
    private int x;
    private int y;
    private string s;
    private ConsoleColor color;

    // properties
    public int X
    {
        get
        {
            return x;
        }
        set
        {
            x = value;
        }
    }
    public int Y
    {
        get
        {
            return y;
        }
        set
        {
            y = value;
        }
    }
    public string S
    {
        get
        {
            return s;
        }
        set
        {
            s = value;
        }
    }

    public ConsoleColor Color
    {
        get
        {
            return color;
        }
        set
        {
            color = value;
        }
    }

    // constructor
    public FoodAndRocks(int x, int y, string s, ConsoleColor color)
    {
        this.X = x;
        this.Y = y;
        this.S = s;
        this.Color = color;
    }

    public static void FRGenerator()
    {

        // declarations
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        int playfieldWidth = 69;
        int playfieldHight = 24;

        int score = 0;

        Random randomGenerator = new Random();

        List<FoodAndRocks> food = new List<FoodAndRocks>();
        List<FoodAndRocks> rocks = new List<FoodAndRocks>();

        while (true)
        {
            bool hitted = false;
            {
                // chance generator
                int chance = randomGenerator.Next(0, 100);

                // generate rocks
                if (chance <= 2 || chance > 45 && chance <= 47 || chance > 65 && chance <= 67)
                {
                    FoodAndRocks rock = new FoodAndRocks(randomGenerator.Next(0, playfieldWidth), randomGenerator.Next(0, playfieldHight), "A", ConsoleColor.Gray);
                    if (rocks.Count < 6)
                    {
                        rocks.Add(rock);
                    }
                }

                // generate food
                else if (chance > 15 && chance <= 17)
                {
                    FoodAndRocks newFood = new FoodAndRocks(0, randomGenerator.Next(0, playfieldHight), "*", ConsoleColor.Red);

                    if (food.Count < 6)
                    {
                        food.Add(newFood);
                    }
                    else if (food.Count > 3)
                    {
                        food.Add(newFood);
                        food.RemoveAt(0);
                    }
                }

                else if (chance > 30 && chance <= 32)
                {
                    FoodAndRocks newFood = new FoodAndRocks(0, randomGenerator.Next(0, playfieldHight), "+", ConsoleColor.Red);

                    if (food.Count < 6)
                    {
                        food.Add(newFood);
                    }
                    else if (food.Count > 3)
                    {
                        food.Add(newFood);
                        food.RemoveAt(0);
                    }
                }

                else if (chance > 60 && chance <= 62)
                {
                    FoodAndRocks newFood = new FoodAndRocks(0, randomGenerator.Next(0, playfieldHight), "@", ConsoleColor.Red);

                    if (food.Count < 6)
                    {
                        food.Add(newFood);
                    }
                    else if (food.Count > 3)
                    {
                        food.Add(newFood);
                        food.RemoveAt(0);
                    }
                }
            }

            // adds new food and new rocks
            List<FoodAndRocks> newList = new List<FoodAndRocks>();
            for (int i = 0; i < food.Count; i++)
            {
                score++;
                FoodAndRocks oldFood = food[i];
                FoodAndRocks newFood = new FoodAndRocks(oldFood.X, oldFood.Y, oldFood.S, oldFood.Color);
                if (oldFood.X + 1 <= playfieldWidth)
                {
                    newFood.X = oldFood.X + 1;
                }

                if (newFood.X < playfieldWidth && newList.Count < 6)
                {
                    newList.Add(newFood);
                }
            }
            food = newList;

            // Redraw playfield
            Console.Clear();

            // Print rocks
            foreach (FoodAndRocks item in food)
            {
                PrintOnPosition(item.X, item.Y, item.S, item.color);
            }
            foreach (FoodAndRocks rock in rocks)
            {
                PrintOnPosition(rock.X, rock.Y, rock.S, rock.color);
            }

            // constant speed
            Thread.Sleep(150);


        }
    }

    public static void PrintOnPosition(int x, int y, string s, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(s);
    }
}


