using Algorithms.Common;

namespace Sorting.Coursera;

public static class InsertionSort
{
    public static int[] Sort(int[] input)
    {
        var inputCopy = new int[input.Length];
        input.CopyTo(inputCopy, 0);

        return Sort(inputCopy, 0, inputCopy.Length - 1);
    }

    public static int[] Sort(int[] arr, int startIndex, int endIndex)
    {
        for (var i = startIndex; i < endIndex; i++)
        {
            var j = i + 1;

            while (j > startIndex && arr[j] < arr[j - 1])
            {
                arr.Swap(j, j - 1);
                j--;
            }
        }

        return arr;
    }
}