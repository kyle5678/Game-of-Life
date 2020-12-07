using System;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid.Generate(5, 5, 0.2);
            Grid.PrintGrid();

            Console.Read();
        }
    }
}
