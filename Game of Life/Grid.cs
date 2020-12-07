using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_Life
{
    static class Grid
    {
        public static bool[,] LifeGrid = new bool[,] { };

        public static void Generate(int height, int length, double lifeRate)
        {
            Random rnd = new Random();

            LifeGrid = new bool[height, length];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    LifeGrid[i, j] = rnd.NextDouble() <= lifeRate;
                }
            }
        }

        public static void PrintGrid()
        {
            for (int i = 0; i < LifeGrid.GetLength(0); i++)
            {
                for (int j = 0; j < LifeGrid.GetLength(1); j++)
                {
                    Console.Write(LifeGrid[i, j] ? "* " : ". ");
                }

                Console.WriteLine();
            }
        }

        public static void NextGeneration()
        {

        }

        private static bool CheckTile(int height, int length)
        {
            int livingNeighbors = 0;
            int totalNeighbors = 0;

        }
    }
}
