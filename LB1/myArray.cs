using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTheoryAlgorithm
{
    public class myArray
    {
        public int[] A { get; set; }
        public int N { get; set; }

        public myArray(int n, int type)
        {
            N = n;
            A = new int[N];

            if (type == 1)
            {
                for (int i = 0; i < N; i++)
                {
                    A[i] = i + 1;
                }
            }
            else if (type == 2)
            {
                for (int i = 0; i < N; i++)
                {
                    A[i] = N - i;
                }
            }
            else
            {
                A = GenerateUniqueRandomArray(N, 1, N);
            }
        }

        public static int[] GenerateUniqueRandomArray(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] numbers = Enumerable.Range(minValue, maxValue - minValue + 1).ToArray();
            return numbers.OrderBy(x => random.Next()).ToArray();
        }

        public void Sort1()
        {
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = 0; j < N - i - 1; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        int temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
                }
            }
        }

        public void Sort2()
        {
            for (int i = 1; i < N; i++)
            {
                int key = A[i];
                int j = i - 1;
                while (j >= 0 && A[j] > key)
                {
                    A[j + 1] = A[j];
                    j--;
                }
                A[j + 1] = key;
            }
        }
    }
}
