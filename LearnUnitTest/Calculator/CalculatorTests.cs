namespace LearnUnitTest;

public class CalculatorTests
{
    private readonly Calculator _calculator;
    public CalculatorTests()
    {
        _calculator = new Calculator();
    }
    [Fact]
    public void SumCalculator()
    {
            var result = _calculator.Sum(3,4);
            Assert.Equal(7,result);
    }

    [Fact]
    public void SubtractCalculator()
    {
        var result = _calculator.Subtract(10,4);
        Assert.Equal(6,result);
    }

    [Fact]
    public void MultiplyCalculator()
    {
        var result = _calculator.Multiply(2,3);
        Assert.Equal(2, result);
    }

    [Fact]
    public void DivideCalculator()
    {
        var result = _calculator.Divide(2,3);
        Assert.Equal(2, result);
    }
}