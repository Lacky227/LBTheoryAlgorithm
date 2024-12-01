using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LBTheoryAlgorithm
{
    public class myArray2 : myArray
    {
        public int inversionCount { get; set; }
        public myArray2(int N, int type) : base(N, type)
        {

        }

        public void CountInversionsBruteForce()
        {
            inversionCount = 0;
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (A[i] > A[j])
                    {
                        inversionCount++;
                    }
                }
            }
        }

        public void CountInversionsDivideAndConquer()
        {
            inversionCount = MergeSortAndCount(A, 0, N - 1);
        }

        private int MergeSortAndCount(int[] array, int left, int right)
        {
            int inversions = 0;

            if (left < right)
            {
                int middle = (left + right) / 2;

                inversions += MergeSortAndCount(array, left, middle);
                inversions += MergeSortAndCount(array, middle + 1, right);

                inversions += MergeAndCount(array, left, middle, right);
            }

            return inversions;
        }

        private int MergeAndCount(int[] array, int left, int middle, int right)
        {
            int[] leftSubarray = new int[middle - left + 1];
            int[] rightSubarray = new int[right - middle];

            Array.Copy(array, left, leftSubarray, 0, middle - left + 1);
            Array.Copy(array, middle + 1, rightSubarray, 0, right - middle);

            int i = 0, j = 0, k = left, inversions = 0;

            while (i < leftSubarray.Length && j < rightSubarray.Length)
            {
                if (leftSubarray[i] <= rightSubarray[j])
                {
                    array[k++] = leftSubarray[i++];
                }
                else
                {
                    array[k++] = rightSubarray[j++];
                    inversions += (leftSubarray.Length - i);
                }
            }

            while (i < leftSubarray.Length)
            {
                array[k++] = leftSubarray[i++];
            }

            while (j < rightSubarray.Length)
            {
                array[k++] = rightSubarray[j++];
            }

            return inversions;
        }
    }
}
