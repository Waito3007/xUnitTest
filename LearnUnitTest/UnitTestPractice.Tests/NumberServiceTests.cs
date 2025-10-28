namespace LearnUnitTest.NumberService;

public class NumberServiceTests
{
    private readonly NumberService _numberService;

    public NumberServiceTests()
    {
        _numberService = new NumberService();
    }
    [Fact]
    public void EvenNumberTestTrue()
    {
        // arrange
        int num = 4;
        // act
        var result = _numberService.IsEvent(num);
        //assert
        Assert.True(result);
    }

    [Fact]
    public void EvenNumberFalse()
    {
        //arrange
        int num = 5;
        //act
        var result = _numberService.IsEvent(num);
        //assert
        Assert.False(result);
    }
    
}