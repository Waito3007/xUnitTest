namespace LearnUnitTest.UnitTestPractice.Tests;

public class ScoreServiceTests
{
    private readonly ScoreService _scoreService;

    public ScoreServiceTests()
    {
        _scoreService = new ScoreService();
    }

    [Theory]
    [InlineData(new int[] { 90, 80, 70 }, 80)]
    [InlineData(new int[] { 100, 100, 100 }, 100)]
    [InlineData(new int[] { 9, 7, 8 }, 8)]
    public void AvgScore(int[] scores, int exprectedAvg)
    {
        //Arrange
        //Act
        var avg = _scoreService.avgScore(scores);
        // assert
        Assert.Equal(avg,exprectedAvg);
    }
}