namespace Algorithms;

public static class QuickSort
{
    private static readonly Random Random = new();

    public delegate int ChoosePivotIndex(int[] array, int startIndex, int endIndex);

    public static readonly ChoosePivotIndex ChooseFirstElement = (array, index, endIndex) => index;
    public static readonly ChoosePivotIndex ChooseLastElement = (array, index, endIndex) => endIndex;
    public static readonly ChoosePivotIndex ChooseMedianElement = (array, index, endIndex) => {
        var middleElementIndex = index + (endIndex - index) / 2;

        var helper = new[] { array[index], array[endIndex], array[middleElementIndex] };
        Array.Sort(helper);
        
        var medianElement = helper[1];

        return array[middleElementIndex] == medianElement 
            ? middleElementIndex
            : array[index] == medianElement 
                ? index 
                : endIndex;
    };
    
    public static int[] Sort(int[] input, ChoosePivotIndex choosePivotIndex)
    {
        var inputCopy = new int[input.Length];
        input.CopyTo(inputCopy, 0);
        
        return inputCopy.Length < 2 
            ? inputCopy 
            : Sort(inputCopy, 0, inputCopy.Length - 1, choosePivotIndex);
    }

    private static int[] Sort(int[] inputCopy, int startIndex, int endIndex, ChoosePivotIndex choosePivotIndex)
    {
        if (endIndex <= startIndex) return inputCopy;

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