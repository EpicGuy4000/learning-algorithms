using Algorithms.Common;

namespace Sorting.Coursera;

public static class MergeSort
{
    public static int[] Sort(int[] input) =>
        input.Length switch
        {
            < 2 => input,
            _ => Merge(
                Sort(input.SubArray(0, input.Length / 2)),
                Sort(input.SubArray(input.Length / 2, input.Length - input.Length / 2)))
        };

    private static int[] Merge(int[] firstHalf, int[] secondHalf)
    {
        var merged = new int[firstHalf.Length + secondHalf.Length];

        for (int i = 0, j = 0, x = 0; x < merged.Length;)
        {
            if (i == firstHalf.Length)
            {
                merged[x++] = secondHalf[j++];
            }
            else if (j == secondHalf.Length || firstHalf[i] < secondHalf[j])
            {
                merged[x++] = firstHalf[i++];
            }
            else
            {
                merged[x++] = secondHalf[j++];
            }
        }

        return merged;
    }
}