using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharksGame1
{
    public class Intro
    {
        public static void Menu()
        {
            int MenuBarKeys = 0;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            bool menu = true;
            int mod = 0;
            while (menu)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (MenuBarKeys < 2)
                        {
                            MenuBarKeys++;
                        }

                    }
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (MenuBarKeys > 0)
                        {
                            MenuBarKeys--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        if (MenuBarKeys == 0)
                        {
                            menu = false;
                        }
                        else if (MenuBarKeys == 1)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Use arrow keys to control SHARK.");
                            System.Threading.Thread.Sleep(600);
                            Console.WriteLine("Don't let the scary rocks hit you.");
                            System.Threading.Thread.Sleep(600);
                            Console.WriteLine("They're standing still anyway.");
                            System.Threading.Thread.Sleep(600);
                            Console.WriteLine("Eat some nasty people that get in your way and you might get a second life");
                            System.Threading.Thread.Sleep(600);
                            Console.WriteLine("Or third...");
                            System.Threading.Thread.Sleep(600);
                            Console.WriteLine("Have a nice game experience!!!");
                            System.Threading.Thread.Sleep(3000);

                        }
                        else if (MenuBarKeys == 2)
                        {
                            Environment.Exit(0);
                        }

                    }
                }
                PrintSharkLogo(mod);
                PrintSharkLogo2(mod);
                MenuButtons(MenuBarKeys);
                MenuMargin(mod);
                System.Threading.Thread.Sleep(120);
                mod++;
                Console.Clear();
            }
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

            int modMovement = 0;
            int x = 0;
            int y = 5;
            bool gameplay = true;
            while (gameplay)
            {
                if (Console.KeyAvailable)
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
                }
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (modMovement == 0)
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

                }
                if (modMovement == 1)
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
                }
                if (modMovement == 2)
                {

                    Console.SetCursorPosition(x, y);
                    for (int i = 0; i < sharkU.Length; i++)
                    {
                        if (y == 1)
                        {
                            y = Console.WindowHeight - 4;
                        }
                        y--;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(sharkU[i]);
                        Console.SetCursorPosition(x, y);

                    }
                    y = y + 4;
                }
                if (modMovement == 3)
                {
                    Console.SetCursorPosition(x, y);
                    for (int i = 0; i < sharkD.Length; i++)
                    {
                        if (y == Console.WindowHeight - 2)
                        {
                            y = 4;
                        }
                        y++;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(sharkD[i]);
                        Console.SetCursorPosition(x, y);

                    }
                    y = y - 4;

                }
                PrintPlayField();
                System.Threading.Thread.Sleep(80);
                Console.Clear();
            }

        }
        static void PrintPlayField()
        {
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
        }
        static void PrintOnPosition(int x, int y, string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        static void PrintSharkLogo(int mod)
        {
            string shark = @"    _________         .    .  
       (..       \_    ,  |\  /|
        \       0  \  /|  \ \/ /
         \______    \/ |   \  /
            vvvv\    \ |   /  |
            \^^^^  ==   \_/   |
             `\_   ===    \.  |
             / /\_   \ /      |
             |/   \_  \|      /
                    \________/";
            if (mod % 2 == 0)
            {
                PrintOnPosition(4, 4, shark, ConsoleColor.Cyan);

            }
            else
            {
                PrintOnPosition(4, 4, shark, ConsoleColor.Blue);

            }
        }
        static void PrintSharkLogo2(int mod)
        {
            string logo = @".|'''|  '||  ||`      /.\      '||'''|, '||  //' 
             ||       ||  ||      // \\      ||   ||  || //   
             `|'''|,  ||''||     //...\\     ||...|'  ||<<    
              .   ||  ||  ||    //     \\    || \\    || \\   
              |...|' .||  ||. .//       \\. .||  \\. .||  \\.";
            if (mod % 2 == 0)
            {
                PrintOnPosition(13, 16, logo, ConsoleColor.Cyan);

            }
            else
            {
                PrintOnPosition(13, 16, logo, ConsoleColor.Blue);

            }
        }
        static void MenuButtons(int modulation)
        {

            if (modulation == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(43, 6);
                Console.Write("==START==");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(43, 8);
                Console.Write("==INFO===");
                Console.SetCursorPosition(43, 10);
                Console.Write("==END====");
            }
            else if (modulation == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(43, 8);
                Console.Write("==INFO===");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(43, 6);
                Console.Write("==START==");
                Console.SetCursorPosition(43, 10);
                Console.Write("==END====");
            }
            else if (modulation == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(43, 10);
                Console.Write("==END====");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(43, 6);
                Console.Write("==START==");
                Console.SetCursorPosition(43, 8);
                Console.Write("==INFO===");
            }

        }
        static void MenuMargin(int mod)
        {
            string UpAndDown = new string('=', 13);
            Console.SetCursorPosition(41, 4);
            Console.Write(UpAndDown);
            Console.SetCursorPosition(41, 12);
            Console.Write(UpAndDown);
        }

    }
}

