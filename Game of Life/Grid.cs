using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_Life
{
    static class Grid
    {
        public static bool[,] LifeGrid = new bool[,] { };

        /// <summary>
        /// Generate a new Life Grid.
        /// </summary>
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

        public static void InputGrid()
        {
            Console.WriteLine("Type out grid below: (*) for living cell, (.) for dead cell, enter twice for end. NO SPACES");
            List<List<bool>> grid = new List<List<bool>>();

            for (; ; )
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "")
                    break;

                else
                {
                    List<bool> gridRow = new List<bool>();

                    for (int i = 0; i < inputLine.Length; i++)
                    {
                        char inputChar = inputLine[i];
                        if (inputChar == '*')
                            gridRow.Add(true);
                        else if (inputChar == '.')
                            gridRow.Add(false);
                        else
                            Console.WriteLine($"NOOOOOOOOOOOO!!! WE FOUND A ({inputChar}) IN HERE!!! THAT'S WRONG!!! ONLY (*) AND (.)!!!");
                    }

                    grid.Add(gridRow);
                }
            }

            Console.WriteLine("done. array-ifying now.");
            LifeGrid = new bool[grid.Count, grid[0].Count];
            
            int j = 0;
            foreach (List<bool> list in grid)
            {
                int k = 0;
                foreach (bool supposedTile in list)
                {

                    LifeGrid[j, k] = supposedTile;
                    k++;
                }

                j++;
            }
        }

        /// <summary>
        /// Print the current Life Grid.
        /// </summary>
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

        /// <summary>
        /// Advance to the next generation.
        /// </summary>
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

        /// <summary>
        /// Check to see if tile at x,y will live/dead in next generation.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
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
