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
            bool[,] newLifeGrid = new bool[LifeGrid.GetLength(0), LifeGrid.GetLength(1)];
            int changes = 0;

            for (int i = 0; i < LifeGrid.GetLength(0); i++)
            {
                for (int j = 0; j < LifeGrid.GetLength(1); j++)
                {
                    newLifeGrid[i, j] = CheckTile(i, j);

                    if (LifeGrid[i, j] != CheckTile(i, j))
                        changes++;
                }
            }

            LifeGrid = newLifeGrid;
            Console.WriteLine($"Life Grid went through ({changes}) changes!");
        }

        public static bool CheckTile(int y, int x)
        {
            int livingNeighbors = 0;
            int totalNeighbors = 0;
            bool living = LifeGrid[y, x];

            // long thing could probably be made shorter
            if (y > 0 && x > 0)
            {
                totalNeighbors++;
                if (LifeGrid[y - 1, x - 1])
                {
                    livingNeighbors++;
                }
            }

            if (y > 0)
            {
                totalNeighbors++;
                if (LifeGrid[y - 1, x])
                {
                    livingNeighbors++;
                }
            }

            if (y > 0 && x < LifeGrid.GetLength(1) - 1)
            {
                totalNeighbors++;
                if (LifeGrid[y - 1, x + 1])
                {
                    livingNeighbors++;
                }
            }

            if (x > 0)
            {
                totalNeighbors++;
                if (LifeGrid[y, x - 1])
                {
                    livingNeighbors++;
                }
            }

            if (x < LifeGrid.GetLength(1) - 1)
            {
                totalNeighbors++;
                if (LifeGrid[y, x + 1])
                {
                    livingNeighbors++;
                }
            }

            if (y < LifeGrid.GetLength(0) - 1 && x > 0)
            {
                totalNeighbors++;
                if (LifeGrid[y + 1, x - 1])
                {
                    livingNeighbors++;
                }
            }

            if (y < LifeGrid.GetLength(0) - 1)
            {
                totalNeighbors++;
                if (LifeGrid[y + 1, x])
                {
                    livingNeighbors++;
                }
            }

            if (y < LifeGrid.GetLength(0) - 1 && x < LifeGrid.GetLength(1) - 1)
            {
                totalNeighbors++;
                if (LifeGrid[y + 1, x + 1])
                {
                    livingNeighbors++;
                }
            }
            // end of long thing

            //Console.WriteLine($"{livingNeighbors} living neighbor(s)");
            //Console.WriteLine($"{totalNeighbors} total neighbor(s)");

            if (living)
            {
                if (livingNeighbors < 2)
                    return false;
                else if (livingNeighbors > 3)
                    return false;
                else
                    return true;
            }

            else
            {
                if (livingNeighbors == 3)
                    return true;
                else
                    return false;
            }
        }
    }
}
