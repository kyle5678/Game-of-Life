using System;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Run();
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Sorry, an exception (developer-speak for ERROR) occured...");

                Console.Beep(622, 250);
                Console.Beep(587, 250);
                Console.Beep(466, 250);
                Console.Beep(523, 250);

                Console.WriteLine(e);

                //Console.Write("Would you like to report this to the developer? (y/n) ");
                //if (Console.ReadLine() == "y")
                //{
                //    System.Diagnostics.Process.Start("explorer", "mailto:aklingad@gmail.com");
                //}

                Console.ReadKey();
            }
        }

        private static void Run()
        {
            Console.Write("Would you like to: (1) generate a grid, or (2) manually input a grid? ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("length? ");
                    int length = Convert.ToInt32(Console.ReadLine());
                    Console.Write("height? ");
                    int height = Convert.ToInt32(Console.ReadLine());
                    Console.Write("life rate (from 0 to 1)? ");
                    double liferate = Convert.ToDouble(Console.ReadLine());

                    Grid.Generate(height, length, liferate);
                    break;
                case "2":
                    Grid.InputGrid();
                    break;
                default:
                    Console.WriteLine("You were not meant to do that! Do better next time.");
                    Console.ReadKey();
                    return;
            }

            Grid.PrintGrid();

            for (; ; )
            {
                Console.ReadLine();

                Grid.NextGeneration();
                Grid.PrintGrid();
            }
        }
    }
}
