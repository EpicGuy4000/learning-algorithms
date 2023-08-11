namespace Algorithms;

public static class KaratsubaMultiplication
{
    public static List<int> Multiply(List<int> x, List<int> y)
    {
        if (x.All(u => u == 0) || y.All(u => u == 0)) return new List<int> { 0 };
        
        while(x.Count > y.Count || !IsPowerOfTwo(Convert.ToUInt32(y.Count))) y.Insert(0, 0);
        while(y.Count > x.Count) x.Insert(0, 0);
        
        if (x.Count == 1)
            return Multiply(x[0], y[0]);

        var halfPoint = (int)Math.Ceiling((double)x.Count / 2);
        var (a, b) = (x.GetRange(0, halfPoint), x.GetRange(halfPoint, x.Count - halfPoint));
        var (c, d) = (y.GetRange(0, halfPoint), y.GetRange(halfPoint, x.Count - halfPoint));
        
        var ac = Multiply(a, c);
        var bd = Multiply(b, d);
        var pq = Multiply(Addition(a, b), Addition(c, d));
        var step4 = Subtraction(pq, Addition(ac, bd));
        var acPadded = new List<int>(ac);
        acPadded.AddRange(Enumerable.Repeat(0, x.Count));
        var step4Padded = new List<int>(step4);
        step4Padded.AddRange(Enumerable.Repeat(0, halfPoint));

        var step5 = Addition(Addition(acPadded, step4Padded), bd);

        var result = step5.SkipWhile(u => u == 0).ToList();

        Console.WriteLine($"{string.Join("", x)} * {string.Join("", y)} = {string.Join("", result)}");
        
        return result;
    }

    private static List<int> Multiply(int x, int y)
    {
        var result = new List<int>();
        
        result.Add(x * y % 10);
        if (x * y / 10 > 0) result.Insert(0, x * y / 10);

        return result;
    }

    private static List<int> Subtraction(List<int> x, List<int> y)
    {
        int borrow = 0;
        var result = new List<int>();

        for (int i = x.Count - 1, j = y.Count - 1; i > -1 || j > -1; i--, j--)
        {
            var a = x[i] - borrow;
            var b = j > -1 ? y[j] : 0;
            var total = a - b;
            borrow = 0;

            while (total < 0)
            {
                total += 10;
                borrow += 1;
            }
            
            result.Insert(0, total % 10);
        }

        return result;
    }

    private static List<int> Addition(List<int> x, List<int> y)
    {
        int carry = 0;
        var result = new List<int>();

        for (int i = x.Count - 1, j = y.Count - 1; i > -1 || j > -1; i--, j--)
        {
            var a = i > -1 ? x[i] : 0;
            var b = j > -1 ? y[j] : 0;
            var total = a + b + carry;
            
            result.Insert(0, total % 10);
            carry = total / 10;
        }

        while (carry != 0)
        {
            result.Insert(0, carry % 10);
            carry /= 10;
        }

        return result;
    }
    
    private static bool IsPowerOfTwo(uint x) => (x & (x - 1)) == 0;
}