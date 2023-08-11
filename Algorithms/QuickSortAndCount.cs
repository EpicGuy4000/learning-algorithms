namespace Algorithms;

public static class QuickSortAndCount
{
    public static (int[] sorted, int comparisonCount) Sort(int[] input, Func<int[], int, int, int> getPivotIndexFunction)
    {
        var inputCopy = new int[input.Length];
        input.CopyTo(inputCopy, 0);
        
        return Sort(inputCopy, 0, inputCopy.Length - 1, getPivotIndexFunction);
    }

    private static (int[] sorted, int comparisonCount) Sort(int[] inputCopy, int startIndex, int endIndex, Func<int[], int, int, int> getPivotIndexFunction)
    {
        if (endIndex <= startIndex) return (inputCopy, 0);

        var pivotIndex = getPivotIndexFunction(inputCopy, startIndex, endIndex);
        
        Swap(inputCopy, pivotIndex, startIndex); // set pivot as starting element
        
        var i = startIndex + 1;

        for (var j = startIndex + 1; j <= endIndex; j++)
        {
            if (inputCopy[j] < inputCopy[startIndex])
            {
                Swap(inputCopy, i, j);
                i++;
            }
        }

        var newPivotIndex = i - 1;
        
        Swap(inputCopy, startIndex, newPivotIndex);

        var (_, firstHalfCount) = Sort(inputCopy, startIndex, newPivotIndex - 1, getPivotIndexFunction);
        var (_, secondHalfCount) = Sort(inputCopy,  newPivotIndex + 1, endIndex, getPivotIndexFunction);

        return (inputCopy, firstHalfCount + secondHalfCount + endIndex - startIndex);
    }

    private static void Swap(Span<int> array, int from, int to)
    {
        if (from == to) return;
        
        array[from] ^= array[to];
        array[to] ^= array[from];
        array[from] ^= array[to];
    }
}