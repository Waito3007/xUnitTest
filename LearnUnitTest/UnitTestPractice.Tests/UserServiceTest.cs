using LearnUnitTest.UnitTestPractice.Interface;
using LearnUnitTest.UnitTestPractice.Model;
using Moq;

namespace LearnUnitTest.UnitTestPractice.Tests;

public class UserServiceTest
{
    private readonly Mock<IUserRepository> _repoMock;
    private readonly UserService _userService; 

    public UserServiceTest()
    {
        _repoMock = new Mock<IUserRepository>();
        _userService = new UserService(_repoMock.Object);
    }

    [Fact]
    public async Task GetUserNameAsync_ReturnsName()
    {
        // Arrange 
        _repoMock.Setup(x => x.GetById(1))
            .ReturnsAsync(new User { Id = 1, Name = "Sang" });

        // Act
        var result = await _userService.GetUserNameAsync(1);

        // Assert
        Assert.Equal("Sang", result);
        _repoMock.Verify(r => r.GetById(1), Times.Once);
    }
    [Fact]
    public async Task GetById_User()
    {
        // Arrange
        var user = new User { Id = 1, Name = "Sang" };
        _repoMock.Setup(x => x.GetById(1))
            .ReturnsAsync(user);
        // act
        var result = await _userService.GetById(1);
        // assert
        Assert.Equal(user,result);
        _repoMock.Verify(r => r.GetById(1), Times.Once);
    }
}