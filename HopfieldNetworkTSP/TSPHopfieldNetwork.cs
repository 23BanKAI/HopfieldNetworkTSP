using System;
using System.IO;
using System.Text;

namespace HopfieldNetworkTSP
{
    class TSPHopfieldNetwork
    {
        static int N = 6; // Количество городов
        static double[,] W = new double[N, N]; // Весовая матрица
        static int[] path = new int[N]; // Лучший путь, найденный алгоритмом
        static double minLength = Double.PositiveInfinity; // Длина найденного лучшего пути

        public void HopfieldAlgorithm(double[,] D)
        {
            // Инициализация весовой матрицы
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    W[i, j] = -D[i, j];
                }
            }

            // Запуск алгоритма сети Хопфилда
            int[] perm = new int[N];
            for (int i = 0; i < N; i++)
            {
                perm[i] = i;
            }
            int[] input = new int[N * N];
            int[] output = new int[N];
            HopfieldNetwork hopfield = new HopfieldNetwork(N * N);
            //hopfield.Train(W, 1000); // Вызываем метод обучения перед итерациями
            int iterations = 1000;
            Random rand = new Random();
            string textMatrix = "Промежуточные матрицы";
            for (int i = 0; i < iterations; i++)
            {
                input = Shuffle(perm, rand);
                hopfield.SetInput(input);
                hopfield.Update();
                output = hopfield.GetOutput();
                int[] currentPath = Decode(output);
                double length = GetLength(currentPath, D);
                textMatrix += $"\nIteration {i + 1}:" + "\nPermutation: " + string.Join(" ", perm) + "\nWeights Matrix:\n" + MatrixToString(W) + "\nPath\n" + string.Join(" ", output) +
                    "\nCurrent Path: " + string.Join(" ", currentPath) + $"\nCurrent Length: {length}\n";
                if (length < minLength)
                {
                    minLength = length;
                    Array.Copy(currentPath, path, N);
                }
            }

            // Выводим лучший найденный путь
            string textToFile = textMatrix + "\nBest Path: ";
            for (int i = 0; i < N; i++)
            {
                textToFile += path[i] + 1 + " ";
            }

            textToFile += "\nLength: " + minLength;
            string filePath = "result.txt";

            File.WriteAllText(filePath, textToFile);
        }

        static int[] Shuffle(int[] perm, Random rand)
        {
            int[] shuffled = new int[N * N];
            Array.Copy(perm, shuffled, N);
            for (int i = 0; i < N - 1; i++)
            {
                int j = rand.Next(i, N);
                int temp = shuffled[i];
                shuffled[i] = shuffled[j];
                shuffled[j] = temp;
            }
            return shuffled;
        }

        static int[] Decode(int[] output)
        {
            int[] decodedPath = new int[N];
            bool[] used = new bool[N];
            int index = 0;
            for (int i = 0; i < N * N; i++)
            {
                int city = output[i];
                if (!used[city])
                {
                    decodedPath[index++] = city;
                    used[city] = true;
                }
            }
            return decodedPath;
        }

        static double GetLength(int[] path, double[,] D)
        {
            double length = 0;
            for (int i = 0; i < N - 1; i++)
            {
                int from = path[i];
                int to = path[i + 1];
                length += D[from, to];
            }
            length += D[path[N - 1], path[0]];
            return length;
        }

        static string MatrixToString(double[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j]).Append("\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
