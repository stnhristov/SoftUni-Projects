namespace RPG_Demo1
{
#if WINDOWS || XBOX

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }

#endif
}