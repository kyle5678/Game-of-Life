using System;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid.InputGrid();
            //Grid.Generate(5, 5, 0.5);

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
