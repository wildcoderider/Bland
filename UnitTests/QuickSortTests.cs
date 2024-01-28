using System;
using BlandGroup;

namespace UnitTests
{
	public class QuickSortTests
	{
        [Fact]
        public void TestQuicksort_Integers()
        {
            int[] array = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3 };
            int[] sortedArray = { 1, 1, 2, 3, 3, 4, 5, 5, 6, 9 };

            QuickSort.Quicksort(array);

            Assert.Equal(sortedArray, array);
        }

        [Fact]
        public void TestQuicksort_Floats()
        {
            float[] array = { 3.14f, 1.1f, 4.5f, 1.0f, 5.2f, 9.8f, 2.7f, 6.0f, 5.5f, 3.3f };
            float[] sortedArray = { 1.0f, 1.1f, 2.7f, 3.14f, 3.3f, 4.5f, 5.2f, 5.5f, 6.0f, 9.8f };

            QuickSort.Quicksort(array);

            Assert.Equal(sortedArray, array);
        }
    }
}

