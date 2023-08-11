using Algorithms.Common;

namespace Sorting.Coursera;

public static class InversionCounter
{
    public static long CountInversions(int[] input) => SortAndCount(input).numberOfInversions;

    private static (int[] sorted, long numberOfInversions) SortAndCount(int[] input)
    {
        if (input.Length < 2)
            return (input, 0);

        var (firstHalfSorted, firstHalfInversionCount) = SortAndCount(input.SubArray(0, input.Length / 2));
        var (secondHalfSorted, secondHalfInversionCount) = SortAndCount(input.SubArray(input.Length / 2, input.Length - input.Length / 2));

        var (mergedSorted, inversionsCountWhileMerging) = MergeAndCount(firstHalfSorted, secondHalfSorted);
        
        return (mergedSorted, firstHalfInversionCount + secondHalfInversionCount + inversionsCountWhileMerging);
    }

    private static (int[] merged, long numberOfInversions) MergeAndCount(int[] firstHalf, int[] secondHalf)
    {
        var merged = new int[firstHalf.Length + secondHalf.Length];
        long inversionsCount = 0;

        for (int i = 0, j = 0, x = 0; x < merged.Length;)
        {
            if (i == firstHalf.Length)
            {
                merged[x++] = secondHalf[j++];
            }
            else if (j == secondHalf.Length || firstHalf[i] <= secondHalf[j])
            {
                merged[x++] = firstHalf[i++];
            }
            else
            {
                merged[x++] = secondHalf[j++];
                inversionsCount += firstHalf.Length - i;
            }
        }

        return (merged, inversionsCount);
    }
}