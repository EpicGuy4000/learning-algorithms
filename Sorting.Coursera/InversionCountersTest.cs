namespace Sorting.Coursera;

public class InversionCountersTest
{
    [Test]
    public void CountInversionSimple1()
    {
        var array = new[] { 5, 4, 1, 8, 7, 2, 6, 3 };
        
        Assert.That(InversionCounter.CountInversions(array), Is.EqualTo(15));
    }
    
    [Test]
    public void CountInversionSimple2()
    {
        var array = new[] { 1, 3, 5, 2, 4, 6 };
        
        Assert.That(InversionCounter.CountInversions(array), Is.EqualTo(3));
    }
    
    [Test]
    public void CountInversionSimple3()
    {
        var array = new[] { 6, 5, 4, 3, 2, 1 };
        
        Assert.That(InversionCounter.CountInversions(array), Is.EqualTo(15));
    }
    
    [Test]
    public void CountInversionTextInput()
    {
        var input = File.ReadAllLines("input_inversion_counter.txt")
            .Where(line => line.Length != 0)
            .Select(int.Parse)
            .ToArray();
        
        Console.WriteLine($"Number of inversions in input is {InversionCounter.CountInversions(input)}");
    }
}