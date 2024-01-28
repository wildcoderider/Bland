using System;

namespace BlandGroup
{
    public class QuickSort
    {
        
        public static void Quicksort<T>(T[] array) where T : IComparable<T>
        {
            // Call the Quicksort method with the entire array
            Quicksort(array, 0, array.Length - 1);
        }

        
        private static void Quicksort<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            // Check if there are more than one element in the current partition
            if (low < high)
            {
                // Find the partition index and partition the array
                int partitionIndex = Partition(array, low, high);

                // Recursively call Quicksort on the left and right partitions
                Quicksort(array, low, partitionIndex - 1);
                Quicksort(array, partitionIndex + 1, high);
            }
        }

        // Private method to find the partition index
        private static int Partition<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            // Choose the pivot element (in this case, the rightmost element)
            T pivot = array[high];
            int i = low - 1;

            // Iterate through the elements in the partition
            for (int j = low; j < high; j++)
            {
                // If the current element is less than or equal to the pivot, swap it with the element at index i+1
                if (array[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            // Swap the pivot element with the element at index i+1
            Swap(array, i + 1, high);
            return i + 1; // Return the index where the pivot is now placed
        }

        
        private static void Swap<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}


