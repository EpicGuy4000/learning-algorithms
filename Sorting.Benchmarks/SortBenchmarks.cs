using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Sorting.Coursera;

namespace Sorting.Benchmarks;

[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser]
[HtmlExporter]
public class SortBenchmarks
{
    private int[] data;
    private int[] sortedData;

    [Params(1000, 10000, 100000)]
    public int N;

    [GlobalSetup]
    public void Setup()
    {
        data = new int[N];
        var random = new Random();
        for (var i = 0; i < N;)
        {
            var val = random.Next();
            if (data.Contains(val)) continue;
            
            data[i] = val;
            i++;
        }

        sortedData = new int[data.Length];
        data.CopyTo(sortedData, 0);
        Array.Sort(sortedData);
    }

    [Benchmark]
    public int[] MergeSortRun() => MergeSort.Sort(data);
    
    [Benchmark]
    public int[] QuickSortFirstElementRun() => QuickSort.Sort(data, QuickSort.ChooseFirstElement);
    
    [Benchmark]
    public int[] QuickSortWithInsertionSortFirstElementRun() => QuickSortWithInsertionSort.Sort(data, QuickSort.ChooseFirstElement);
    
    [Benchmark]
    public int[] QuickSortLastElementRun() => QuickSort.Sort(data, QuickSort.ChooseLastElement);
    
    [Benchmark]
    public int[] QuickSortMedianElementRun() => QuickSort.Sort(data, QuickSort.ChooseMedianElement);
    
    [Benchmark]
    public int[] QuickSortMedianEveryTimeRun() => QuickSort.Sort(sortedData, QuickSort.ChooseMedianElement);
    
    //[Benchmark]
    public int[] MergeSortWithEnumerableRun() => MergeSortWithEnumerable.Sort(data);

    [Benchmark]
    public int[] DefaultSortRun()
    {
        var sorted = new int[data.Length];
            
        Array.Copy(data, sorted, data.Length);
        Array.Sort(sorted);

        return sorted;
    }
}