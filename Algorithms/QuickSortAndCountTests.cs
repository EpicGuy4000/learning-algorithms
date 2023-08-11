namespace Algorithms;

public class QuickSortAndCountTests
{
    [Test]
    public void Example()
    {
        var input = new[] { 3, 8, 2, 5, 1, 4, 7, 6 };
        
        var (_, count) = QuickSortAndCount.Sort(input, (_, si, ei) => si);
        
        Console.WriteLine($"Done in {count} comparisons");
    }
    
    [Test]
    public void ProblemOne()
    {
        var input = File.ReadAllLines("input_quick_sort.txt")
            .Where(line => line.Length != 0)
            .Select(int.Parse)
            .ToArray();

        var (_, count) = QuickSortAndCount.Sort(input, (_, si, ei) => si);
        
        Console.WriteLine($"When always using the first element, number of comparisons is {count}");
    }

    [TestCase(10, 25)]
    [TestCase(100, 620)]
    [TestCase(1000, 11175)]
    public void FirstElementIsPivot_Subset(int firstN, int expectedCount)
    {
        var input = File.ReadAllLines("input_quick_sort.txt")
            .Where(line => line.Length != 0)
            .Select(int.Parse)
            .Take(firstN)
            .ToArray();

        var (_, count) = QuickSortAndCount.Sort(input, (_, si, ei) => si);
        
        Assert.That(count, Is.EqualTo(expectedCount));
    }

    [TestCase(10, 31)]
    [TestCase(100, 573)]
    [TestCase(1000, 10957)]
    public void LastElementIsPivot_Subset(int firstN, int expectedCount)
    {
        var input = File.ReadAllLines("input_quick_sort.txt")
            .Where(line => line.Length != 0)
            .Select(int.Parse)
            .Take(firstN)
            .ToArray();

        var (_, count) = QuickSortAndCount.Sort(input, (_, si, ei) => ei);
        
        Assert.That(count, Is.EqualTo(expectedCount));
    }

    [TestCase(10, 21)]
    [TestCase(100, 502)]
    [TestCase(1000, 9735)]
    public void MedianElementIsPivot_Subset(int firstN, int expectedCount)
    {
        var input = File.ReadAllLines("input_quick_sort.txt")
            .Where(line => line.Length != 0)
            .Select(int.Parse)
            .Take(firstN)
            .ToArray();

        var (_, count) = QuickSortAndCount.Sort(input, (arr, si, ei) =>
        {
            var middleElementIndex = si + (ei - si) / 2;

            if (arr[si] <= arr[ei] && arr[si] >= arr[middleElementIndex]
                || arr[si] >= arr[ei] && arr[si] <= arr[middleElementIndex]) return si;
            if (arr[ei] <= arr[si] && arr[ei] >= arr[middleElementIndex]
                || arr[ei] >= arr[si] && arr[ei] <= arr[middleElementIndex]) return ei;

            return middleElementIndex;
        });
        
        Assert.That(count, Is.EqualTo(expectedCount));
    }

    [Test]
    public void ProblemTwo()
    {
        var input = File.ReadAllLines("input_quick_sort.txt")
            .Where(line => line.Length != 0)
            .Select(int.Parse)
            .ToArray();

        var (_, count) = QuickSortAndCount.Sort(input, (_, si, ei) => ei);
        
        Console.WriteLine($"When always using the last element, number of comparisons is {count}");
    }
    
    [Test]
    public void ProblemThree()
    {
        var input = File.ReadAllLines("input_quick_sort.txt")
            .Where(line => line.Length != 0)
            .Select(int.Parse)
            .ToArray();

        var (_, count) = QuickSortAndCount.Sort(input, (arr, si, ei) =>
        {
            var middleElementIndex = si + (ei - si) / 2;

            if (arr[si] <= arr[ei] && arr[si] >= arr[middleElementIndex]
                || arr[si] >= arr[ei] && arr[si] <= arr[middleElementIndex]) return si;
            if (arr[ei] <= arr[si] && arr[ei] >= arr[middleElementIndex]
                || arr[ei] >= arr[si] && arr[ei] <= arr[middleElementIndex]) return ei;

            return middleElementIndex;
        });
        
        Console.WriteLine($"When always using the median element, number of comparisons is {count}");
    }
}