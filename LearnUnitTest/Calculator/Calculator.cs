namespace LearnUnitTest;

public class Calculator
{
    public int Sum (int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public int Divide(int a, int b)
    {
        if ( b == 0 )
        {
            throw new DivideByZeroException("Denominator cannot be zero.");
        }
        return a / b;
    }
}