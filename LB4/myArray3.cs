using LBTheoryAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB4
{
    public class myArray3 : myArray
    {
        public int[] Bolts;
        public int[] Nuts;
        private static Random random = new Random();

        public myArray3(int N, int type) : base(N, type)
        {
            Bolts = (int[])A.Clone();
            Nuts = (int[])A.Clone();

            Shuffle(Nuts);
        }

        public void QuickSortNutsAndBolts()
        {
            QuickSort(0, N - 1);
        }

        public void SortNutsAndBoltsRandomized()
        {
            RandomizedQuickSort(0, N - 1);
        }

        private void QuickSort(int low, int high)
        {
            while (low < high)
            {
                int partitionIndex = Partition(Nuts, Bolts[high], low, high);
                Partition(Bolts, Nuts[partitionIndex], low, high);

                QuickSort(low, partitionIndex - 1);
                low = partitionIndex + 1;
            }
        }

        public void RandomizedQuickSort(int low, int high)
        {
            while (low < high)
            {
                int pivotIndex = random.Next(low, high + 1);
                Swap(Bolts, pivotIndex, high);

                int partitionIndex = Partition(Nuts, Bolts[high], low, high);
                Partition(Bolts, Nuts[partitionIndex], low, high);

                RandomizedQuickSort(low, partitionIndex - 1);
                low = partitionIndex + 1;
            }
        }

        private void Shuffle(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        private int Partition(int[] arr, int pivot, int low, int high)
        {
            int i = low;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    Swap(arr, i, j);
                    i++;
                }
                else if (arr[j] == pivot)
                {
                    Swap(arr, j, high);
                    j--;
                }
            }
            Swap(arr, i, high);
            return i;
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
