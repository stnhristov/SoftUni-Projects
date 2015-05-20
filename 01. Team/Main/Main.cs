using System;
using System.Threading;
using SharksGame1;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Intro.Menu);
            Thread thread2 = new Thread(FoodAndRocks.FRGenerator);
            //Thread thread = new Thread(Shark.Shark.SharkGenerator);
            thread1.Start();
            thread2.Start();
            //thread.Start();
        }
    }
}
