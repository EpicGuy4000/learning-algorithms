using Algorithms.Common;

namespace Sorting.Coursera;

public static class MergeSortWithEnumerable
{
    public static int[] Sort(int[] input) => SortToEnumerable(input).ToArray();

    private static IEnumerable<int> SortToEnumerable(int[] input) =>
        input.Length switch
        {
            < 2 => input,
            _ => Merge(
                SortToEnumerable(input.SubArray(0, input.Length / 2)),
                SortToEnumerable(input.SubArray(input.Length / 2, input.Length - input.Length / 2)))
        };

    private static IEnumerable<int> Merge(IEnumerable<int> firstHalf, IEnumerable<int> secondHalf)
    {
        using var firstHalfEnumerator = firstHalf.GetEnumerator();
        using var secondHalfEnumerator = secondHalf.GetEnumerator();

        var firstHalfDone = !firstHalfEnumerator.MoveNext();
        var secondHalfDone = !secondHalfEnumerator.MoveNext();

        while (!(firstHalfDone && secondHalfDone))
        {
            if (firstHalfDone)
                yield return GetAndMove(secondHalfEnumerator, out secondHalfDone);
            else if (secondHalfDone || firstHalfEnumerator.Current < secondHalfEnumerator.Current)
                yield return GetAndMove(firstHalfEnumerator, out firstHalfDone);
            else
                yield return GetAndMove(secondHalfEnumerator, out secondHalfDone);
        }
    }

    private static T GetAndMove<T>(IEnumerator<T> enumerator, out bool isDone)
    {
        var val = enumerator.Current;
        isDone = !enumerator.MoveNext();
        return val;
    }
}