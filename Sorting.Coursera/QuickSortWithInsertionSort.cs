namespace Sorting.Coursera;

public static class QuickSortWithInsertionSort
{
    public static int[] Sort(int[] input, QuickSort.ChoosePivotIndex choosePivotIndex)
    {
        var inputCopy = new int[input.Length];
        input.CopyTo(inputCopy, 0);
        
        return inputCopy.Length < 2 
            ? inputCopy 
            : Sort(inputCopy, 0, inputCopy.Length - 1, choosePivotIndex);
    }

    private static int[] Sort(int[] inputCopy, int startIndex, int endIndex, QuickSort.ChoosePivotIndex choosePivotIndex)
    {
        if (endIndex - startIndex < 14) return InsertionSort.Sort(inputCopy, startIndex, endIndex);

        var pivotIndex = choosePivotIndex(inputCopy, startIndex, endIndex);
        
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

        Sort(inputCopy, startIndex, newPivotIndex - 1, choosePivotIndex);
        Sort(inputCopy,  newPivotIndex + 1, endIndex, choosePivotIndex);

        return inputCopy;
    }

    private static void Swap(Span<int> array, int from, int to)
    {
        if (from == to) return;
        
        array[from] ^= array[to];
        array[to] ^= array[from];
        array[from] ^= array[to];
    }
}