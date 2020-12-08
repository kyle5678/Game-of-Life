using System;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                Grid.Generate(5, 5, 0.2);
                Grid.PrintGrid();

                Console.WriteLine($"{Grid.LifeGrid[2, 2]} {Grid.CheckTile(2, 2)}");
                Console.ReadLine();
            }
        }
    }
}
