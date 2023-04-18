using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // Инициализируем весовую матрицу
           
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
            int[] output = new int[N * N];
            HopfieldNetwork hopfield = new HopfieldNetwork(N * N);
            int iterations = 1000;
            Random rand = new Random();
            for (int i = 0; i < iterations; i++)
            {
                input = Shuffle(perm, rand);
                hopfield.SetInput(input);
                hopfield.Update();
                output = hopfield.GetOutput();
                int[] path = Decode(output);
                double length = GetLength(path, D);
                if (length < minLength)
                {
                    minLength = length;
                    Array.Copy(path, TSPHopfieldNetwork.path, N);
                }
            }
            
            // Выводим лучший найденный путь
            string textToFile = "Best Path: ";
            for (int i = 0; i < N; i++)
            {
                textToFile += TSPHopfieldNetwork.path[i] + 1 + " ";
            }

            textToFile += "\nLength: " + TSPHopfieldNetwork.minLength;
            string filePath = "result.txt";
           
            File.WriteAllText(filePath, textToFile);
            /*            SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Title = "Save file";
                        saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                        saveFileDialog.DefaultExt = "txt";
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            writer.Write(textToFile);
                        }*/
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            /*            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = saveFileDialog.FileName;
                            File.WriteAllText(filePath, textToFile);
                        }*/
        }
        // Определяем метод для перемешивания массива
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
        // Определяем метод для декодирования выходного массива
        static int[] Decode(int[] output)
        {
            int[] path = new int[N];
            bool[] used = new bool[N];
            int index = 0;
            for (int i = 0; i < N * N; i++)
            {
                int j = output[i];
                if (!used[j])
                {
                    path[index++] = j;
                    used[j] = true;
                }
            }
            return path;
        }
        // Определяем метод для расчета длины пути
        static double GetLength(int[] path, double[,] D)
        {
            double length = 0;
            for (int i = 0; i < N - 1; i++)
            {
                int j = path[i];
                int k = path[i + 1];
                length += D[j, k];
            }
            length += D[path[N - 1], path[0]];
            return length;
        }
    }
}
