namespace Sorting.Coursera;

public class SortsTests
{
    public delegate int[] Sort(int[] input);
    
    [TestCaseSource(nameof(_sorts))]
    public void ShouldSort(Sort sort)
    {
        var array = new[] { 5, 4, 1, 8, 7, 2, 6, 3 };

        var sorted = sort(array);
        
        Assert.That(sorted, Is.EqualTo(new [] { 1, 2, 3, 4, 5, 6, 7, 8 }));
    }

    private static object[] _sorts =
    {
        new object[] { new Sort(MergeSort.Sort) },
        new object[] { new Sort(MergeSortWithEnumerable.Sort) },
        new object[] { new Sort(input => QuickSort.Sort(input, QuickSort.ChooseFirstElement)) },
        new object[] { new Sort(input =>
        {
            var sorted = new int[input.Length];
            
            Array.Copy(input, sorted, input.Length);
            Array.Sort(sorted);

            return sorted;
        })}
    };
}