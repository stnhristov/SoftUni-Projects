using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharksGame1
{
    class Program
    {
        static void Main(string[] args)
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
                Console.Write("==INFO==");
                Console.SetCursorPosition(43, 10);
                Console.Write("==END==");
            }
            else if (modulation == 1) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(43, 8);
                Console.Write("==INFO==");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(43, 6);
                Console.Write("==START==");
                Console.SetCursorPosition(43, 10);
                Console.Write("==END==");
            }
            else if (modulation == 2) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(43, 10);
                Console.Write("==END==");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(43, 6);
                Console.Write("==START==");
                Console.SetCursorPosition(43, 8);
                Console.Write("==INFO==");
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
