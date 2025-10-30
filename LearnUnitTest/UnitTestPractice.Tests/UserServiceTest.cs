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
    
    // [Fact]
    // public async Task GetById_User()
    // {
    //     // arrange
    //     var user = new User { Id = 1, Name = "Sang" };
    //     _repoMock.Setup(x => x.GetById(1))
    //         .ReturnsAsync(user);
    //     // act
    //     var result = await _userService.GetById(1);
    //     // assert
    //     Assert.Equal(user,result);
    //     _repoMock.Verify(r => r.GetById(1), Times.Once);
    // }
    // [Fact]
    // public async Task GetUserNameAsync_ReturnsNotFound()
    // {
    //     // arrange
    //     _repoMock.Setup(x => x.GetById(99))
    //         .ReturnsAsync((User?)null);
    //
    //     // act
    //     var result = await _userService.GetUserNameAsync(99);
    //
    //     // assert
    //     Assert.Equal("Not found", result);
    //     _repoMock.Verify(r => r.GetById(99), Times.Once);
    // }
}