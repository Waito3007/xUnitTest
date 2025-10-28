using LearnUnitTest.UnitTestPractice.Interface;
using Moq;

namespace LearnUnitTest.UnitTestPractice.Tests;

public class UserServiceTest
{
    private readonly Mock<IUserService> _userServiceMock;
    public UserServiceTest()
    {
        _userServiceMock = new Mock<IUserService>();

    }

    [Fact]
    public void UserServiceTesting()
    {
        _userServiceMock.Setup(x => x.GetUserNameAsync(1)).ReturnsAsync("1,Sang");
        var userService = _userServiceMock.Object;
        var result = userService.GetUserNameAsync(1).Result;
        Assert.Equal("1,Sang", result);
    }
}