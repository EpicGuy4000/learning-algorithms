namespace Algorithms.Common;

public static class ArrayExtensions
{
    public static T[] SubArray<T>(this T[] array, int offset, int length)
    {
        var newArray = new T[length];
        
        Array.Copy(array, offset, newArray, 0, length);

        return newArray;
    }
}