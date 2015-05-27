using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharkGame
{
    class Drawer
    {
// Public fields
        public static List<FoodAndRocks> Food = new List<FoodAndRocks>();
        public static List<FoodAndRocks> Rocks = new List<FoodAndRocks>();
        public static int PlayfieldWidth = 69;
        public static int PlayfieldHight = 24;

        public static void Draw()
        {
// Declarations
            int score = 0;
            Random randomGenerator = new Random();
            Console.CursorVisible = false;
            string sharkRight = ">-==^=:>";
            string sharkLeft = "<-==^=:<";
            char[] sharkR = sharkRight.ToCharArray();
            char[] sharkL = sharkLeft.ToCharArray();
            string sharkDown = "V#>\"V";
            string sharkUp = "^#<\"^";
            char[] sharkD = sharkDown.ToCharArray();
            char[] sharkU = sharkUp.ToCharArray();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

// Settings: 
            int modMovement = 0;
            int x = 0;
            int y = 5;
            bool gameplay = true;

            while (gameplay)
            {
                // change movement direction
                if (Console.KeyAvailable)
                {
                    modMovement = ChooseModMovement(modMovement, ref gameplay);
                }
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                Console.Clear();

                // recalculate X and Y as per chosen movement direction and drow Shark
                if (modMovement == 0)
                {
                    x = Mode10SharkDrawer(x, y, sharkR);
                }
                if (modMovement == 1)
                {
                    x = Mode1XSharkDrawer(x, y, sharkL);
                }
                if (modMovement == 2)
                {
                    y = Mode2YSharkDrawer(x, y, sharkU);
                }
                if (modMovement == 3)
                {
                    y = Mode3YSharkDrawer(x, y, sharkD);
                }

                // generating food and rocks and tracking hits
                bool hitted = false;
                {
                    // chance generator
                    int chance = randomGenerator.Next(0, 100);

                    // generate rocks
                    if (chance <= 2 || chance > 45 && chance <= 47 || chance > 65 && chance <= 67)
                    {
                        GenerateNewRocks(randomGenerator, PlayfieldWidth, PlayfieldHight);
                    }

                    // generate food
                    else if (chance > 15 && chance <= 17)
                    {
                        GenerateNewFood(randomGenerator, PlayfieldHight, "*");
                    }

                    else if (chance > 30 && chance <= 32)
                    {
                        GenerateNewFood(randomGenerator, PlayfieldHight, "+");
                    }

                    else if (chance > 60 && chance <= 62)
                    {
                        GenerateNewFood(randomGenerator, PlayfieldHight, "@");
                    }
                }

                // adds new food 
                GenerateNewFoodList(PlayfieldWidth);

// Main Drawer - print food, rocks and playfield are Drawer methods main part - the rest is just settings
                foreach (FoodAndRocks item in Food)
                {
                    PrintOnPosition(item.X, item.Y, item.S, item.color);
                }
                foreach (FoodAndRocks rock in Rocks)
                {
                    PrintOnPosition(rock.X, rock.Y, rock.S, rock.color);
                }

                for (int i = 0; i < 25; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(0, i);
                    Console.Write('■');
                }
                for (int i = 0; i < 25; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(70, i);
                    Console.Write('■');
                }
                for (int i = 0; i < 70; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(i, 0);
                    Console.Write('■');
                }
                for (int i = 0; i < 70; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(i, 24);
                    Console.Write('■');
                }

                Thread.Sleep(80);
            }
        }

        private static void GenerateNewFood(Random randomGenerator, int playfieldHight, string foodType)
        {
            FoodAndRocks newFood = new FoodAndRocks(0, randomGenerator.Next(0, playfieldHight), foodType, ConsoleColor.Red);

            if (Food.Count < 6)
            {
                Food.Add(newFood);
            }
            else if (Food.Count > 3)
            {
                Food.Add(newFood);
                Food.RemoveAt(0);
            }
        }

        private static void GenerateNewRocks(Random randomGenerator, int playfieldWidth, int playfieldHight)
        {
            FoodAndRocks rock = new FoodAndRocks(randomGenerator.Next(0, playfieldWidth),
                randomGenerator.Next(0, playfieldHight), "A", ConsoleColor.Gray);
            if (Rocks.Count < 6)
            {
                Rocks.Add(rock);
            }
        }

        private static void GenerateNewFoodList(int playfieldWidth)
        {
            List<FoodAndRocks> newList = new List<FoodAndRocks>();
            for (int i = 0; i < Food.Count; i++)
            {
                FoodAndRocks oldFood = Food[i];
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
            Food = newList;
        }

        private static int Mode3YSharkDrawer(int x, int y, char[] sharkD)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < sharkD.Length; i++)
            {
                if (y == PlayfieldHight - 2)
                {
                    y = 4;
                }
                y++;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sharkD[i]);
                Console.SetCursorPosition(x, y);
            }
            y = y - 4;
            return y;
        }

        private static int Mode2YSharkDrawer(int x, int y, char[] sharkU)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < sharkU.Length; i++)
            {
                if (y == 1)
                {
                    y = PlayfieldHight - 4;
                }
                y--;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sharkU[i]);
                Console.SetCursorPosition(x, y);
            }
            y = y + 4;
            return y;
        }

        private static int Mode1XSharkDrawer(int x, int y, char[] sharkL)
        {
            if (x == 0)
            {
                x = 62;
            }
            Console.SetCursorPosition(x, y);
            for (int i = sharkL.Length - 1; i >= 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sharkL[i]);
            }
            x--;
            return x;
        }

        private static int Mode10SharkDrawer(int x, int y, char[] sharkR)
        {
            if (x == 62)
            {
                x = 0;
            }
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < sharkR.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sharkR[i]);
            }
            x++;
            return x;
        }

        private static int ChooseModMovement(int modMovement, ref bool gameplay)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                modMovement = 0;
            }
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                modMovement = 1;
            }
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                modMovement = 2;
            }
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                modMovement = 3;
            }
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                gameplay = false;
                Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    gameplay = true;
                }
            }
            return modMovement;
        }

        public static void PrintOnPosition(int x, int y, string s, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(s);
        }
    }
}
