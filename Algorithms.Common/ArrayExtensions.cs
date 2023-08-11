using System.Numerics;

namespace Algorithms.Common;

public static class ArrayExtensions
{
    public static T[] SubArray<T>(this T[] array, int offset, int length)
    {
        var newArray = new T[length];
        
        Array.Copy(array, offset, newArray, 0, length);

        return newArray;
    }

    public static void Swap<T>(this T[] array, int x, int y) where T : IBitwiseOperators<T, T, T>
    {
        array[x] ^= array[y];
        array[y] ^= array[x];
        array[x] ^= array[y];
    }
}