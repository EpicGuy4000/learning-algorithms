using Coursera.Recursion;

namespace Recursion.Coursera;

public class MultiplicationTests
{
    [Test]
    public void GiveAnswer()
    {
        var a = "3141592653589793238462643383279502884197169399375105820974944592";
        var b = "2718281828459045235360287471352662497757247093699959574966967627";

        var result = KaratsubaMultiplication.Multiply(a.Select(x => int.Parse(x.ToString())).ToList(),
            b.Select(x => int.Parse(x.ToString())).ToList());
        
        Console.WriteLine($"result is {string.Join("", result)}");
        Assert.Pass();
    }
    
    [Test]
    public void ShouldMultiply()
    {
        var result = KaratsubaMultiplication.Multiply(new List<int> { 5, 6, 7, 8 }, new List<int> { 1, 2, 3, 4 });
        
        Console.WriteLine(string.Join("", result));
        Assert.That(result, 
            Is.EqualTo(new List<int> { 7, 0, 0, 6, 6, 5, 2}));
    }
    
    [Test]
    public void ShouldMultiplySimple()
    {
        Assert.That(KaratsubaMultiplication.Multiply(new List<int> { 5 }, new List<int> { 5 }), 
            Is.EqualTo(new List<int> { 2, 5 }));
    }
    
    [Test]
    public void ShouldMultiplySimple2()
    {
        Assert.That(KaratsubaMultiplication.Multiply(new List<int> { 5 }, new List<int> { 1 }), 
            Is.EqualTo(new List<int> { 5 }));
    }
    
    [Test]
    public void ShouldMultiplySimple3()
    {
        Assert.That(KaratsubaMultiplication.Multiply(new List<int> { 1, 0 }, new List<int> { 1, 0 }), 
            Is.EqualTo(new List<int> { 1, 0, 0 }));
    }
    
    [Test]
    public void ShouldMultiplySimple4()
    {
        var result = KaratsubaMultiplication.Multiply(new List<int> { 1, 0 }, new List<int> { 1 });
        
        Console.WriteLine(string.Join("", result));
        Assert.That(result, 
            Is.EqualTo(new List<int> { 1, 0 }));
    }
    
    [Test]
    public void ShouldMultiplySimple5()
    {
        var result = KaratsubaMultiplication.Multiply(new List<int> { 1, 0, 0 }, new List<int> { 5, 2 });
        
        Console.WriteLine(string.Join("", result));
        Assert.That(result, Is.EqualTo(new List<int>{ 5, 2, 0, 0 }));
    }
    
    [Test]
    public void ShouldMultiplySimple6()
    {
        var result = KaratsubaMultiplication.Multiply(new List<int> { 9, 7, 9, 3 }, new List<int> { 9, 0, 4, 5 });
        
        Console.WriteLine(string.Join("", result));
        Assert.That(result, Is.EqualTo(new List<int>{ 8, 8, 5, 7, 7, 6, 8, 5 }));
    }
    
    [Test]
    public void ShouldMultiplySimple7()
    {
        var result = KaratsubaMultiplication.Multiply(new List<int> { 1, 9, 0 }, new List<int> { 1, 3, 5 });
        
        Console.WriteLine(string.Join("", result));
        Assert.That(result, Is.EqualTo(new List<int>{ 2, 5, 6, 5, 0 }));
    }
    
    [Test]
    public void ShouldMultiplySimple8()
    {
        var result = KaratsubaMultiplication.Multiply(new List<int> { 5, 3, 5, 8, 9, 7, 9, 3 }, new List<int> { 2, 8, 4, 5, 9, 0, 4, 5 });
        
        Console.WriteLine(string.Join("", result));
        Assert.That(result, Is.EqualTo(new List<int>{ 1, 5, 2, 5, 1, 1, 4, 3, 3, 0, 5, 2, 7, 6, 8, 5 }));
    }
}