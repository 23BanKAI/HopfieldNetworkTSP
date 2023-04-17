using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopfieldNetworkTSP
{
    class HopfieldNetwork
    {
        private int N; // Количество нейронов
        private double[,] W; // Весовая матрица
        private int[] S; // Состояние нейронов

        public HopfieldNetwork(int N)
        {
            this.N = N;
            this.W = new double[N, N];
            this.S = new int[N];
        }

        public void SetInput(int[] input)
        {
            for (int i = 0; i < N; i++)
            {
                S[i] = input[i];
            }
        }

        public int[] GetOutput()
        {
            return S;
        }

        public void Update()
        {
            for (int i = 0; i < N; i++)
            {
                double sum = 0;
                for (int j = 0; j < N; j++)
                {
                    sum += W[i, j] * S[j];
                }
                if (sum > 0)
                {
                    S[i] = 1;
                }
                else if (sum < 0)
                {
                    S[i] = -1;
                }
            }
        }
    }
}
