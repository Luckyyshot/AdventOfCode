using System;
using System.Collections.Generic;

namespace DumboOctopus
{
    class Octopi
    {
        private readonly int[,] OctopiMatrix;

        public int FlashCount { get; private set; }

        public int StepCount { get; private set; }

        public Octopi(string[] octopi)
        {
            FlashCount = 0;

            OctopiMatrix = new int[octopi[0].Length + 2, octopi.Length + 2];
            for (int i = 1; i < octopi.Length + 1; i++)
            {
                for (int j = 1; j < octopi[i - 1].Length + 1; j++)
                {
                    OctopiMatrix[i, j] = int.Parse(octopi[i - 1][j - 1].ToString());
                }
            }
        }

        public int FindFirstAllFlash()
        {
            bool allFlashed;
            do
            {
                allFlashed = true;
                SimulateStep();
                for (int i = 1; i < OctopiMatrix.GetLength(0) - 1; i++)
                {
                    for (int j = 1; j < OctopiMatrix.GetLength(1) - 1; j++)
                    {
                        if (OctopiMatrix[i, j] != 0)
                            allFlashed = false;
                    }
                }
            } while (!allFlashed);
            return StepCount;
        }

        public void SimulateSteps(int steps)
        {
            for (int i = 0; i < steps; i++)
                SimulateStep();
        }

        void SimulateStep()
        {
            for (int i = 1; i < OctopiMatrix.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < OctopiMatrix.GetLength(1) - 1; j++)
                {
                    OctopiMatrix[i, j]++;
                }
            }

            List<Tuple<int, int>> flasher;
            do
            {
                flasher = new();
                for (int i = 1; i < OctopiMatrix.GetLength(0) - 1; i++)
                {
                    for (int j = 1; j < OctopiMatrix.GetLength(1) - 1; j++)
                    {
                        if (OctopiMatrix[i, j] > 9)
                        {
                            FlashCount++;
                            OctopiMatrix[i, j] = 0;
                            flasher.Add(new Tuple<int, int>(i, j));
                            UpdateAdjacent(i, j);
                        }
                    }
                }
            } while (flasher.Count > 0);
            StepCount++;
        }

        void UpdateAdjacent(int x, int y)
        {
            if (OctopiMatrix[x, y + 1] != 0)
                OctopiMatrix[x, y + 1]++;
            if (OctopiMatrix[x, y - 1] != 0)
                OctopiMatrix[x, y - 1]++;
            if (OctopiMatrix[x + 1, y] != 0)
                OctopiMatrix[x + 1, y]++;
            if (OctopiMatrix[x + 1, y + 1] != 0)
                OctopiMatrix[x + 1, y + 1]++;
            if (OctopiMatrix[x + 1, y - 1] != 0)
                OctopiMatrix[x + 1, y - 1]++;
            if (OctopiMatrix[x - 1, y] != 0)
                OctopiMatrix[x - 1, y]++;
            if (OctopiMatrix[x - 1, y + 1] != 0)
                OctopiMatrix[x - 1, y + 1]++;
            if (OctopiMatrix[x - 1, y - 1] != 0)
                OctopiMatrix[x - 1, y - 1]++;
        }
    }
}
