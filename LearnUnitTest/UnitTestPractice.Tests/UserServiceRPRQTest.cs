using LearnUnitTest.UnitTestPractice.Implement;
using LearnUnitTest.UnitTestPractice.Interface;
using LearnUnitTest.UnitTestPractice.Model;
using Moq;

namespace LearnUnitTest.UnitTestPractice.Tests;

public class UserServiceRPRQTest
{
    private readonly Mock<IUserRepository> _mockRepository;
    private readonly IUserServiceRPRQ _userServiceRPRQ;

    public UserServiceRPRQTest()
    {
        _mockRepository = new Mock<IUserRepository>();
        _userServiceRPRQ = new UserServiceRPRQ(_mockRepository.Object);
    }

    [Fact]
    public async Task GetServerWithResponseRequest_ReturnsServerResponse()
    {
        // arrange
        var request = new ServerType.ServerRequest { Id = 1 };
        var expectedUser = new User { Id = 1, Name = "Sang" };
        _mockRepository.Setup(repo => repo.GetById(request))
            .ReturnsAsync(expectedUser);
        // act 
        var result = await _userServiceRPRQ.GetServerWithResponseRequest(request);
        // assert
        Assert.Equal(expectedUser.Id, result.Id);
       // Assert.Equal(expectedUser.Name, result.Name);
        _mockRepository.Verify(r => r.GetById(request), Times.Once);
    }
}