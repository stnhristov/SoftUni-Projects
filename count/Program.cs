using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace count
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nn = new List<string>();
            Random rand = new Random();
            
            
            while (true) 
            {
                int r = rand.Next(0,7 );
                switch (r) 
                {
                    case 0: nn.Add("John"); break;
                    case 1: nn.Add("Leroy"); break;
                    case 2: nn.Add("Samurai"); break;
                    case 3: nn.Add("John"); break;
                    case 4: nn.Add("Smelt"); break;
                    default: nn.Add("Guzt"); break;
                }
                Console.WriteLine("The amount of Johns is: "+nn.Count(a => a == "John"));
                Console.WriteLine("The amount of Leroys is: " + nn.Count(a => a == "Leroy"));
                Console.WriteLine("The amount of Samurais is: " + nn.Count(a => a == "Samurai"));
                Console.WriteLine("The amount of Smelts is: " + nn.Count(a => a == "Smelt"));
                Console.WriteLine("The amount of Guzts is: " + nn.Count(a => a == "Guzt"));
               
                System.Threading.Thread.Sleep(20);
                Console.Clear();
 
            }
        }
    }
}
