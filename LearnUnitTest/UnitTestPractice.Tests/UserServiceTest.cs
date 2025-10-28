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
    public async Task GetUserNameAsync_WithValidId_ReturnsUserName()
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
    public async Task GetUserNameAsync_WithInvalidId_ReturnsNotFound()
    {
        // Arrange
        _repoMock.Setup(x => x.GetById(99))
            .ReturnsAsync((User?)null);

        // Act
        var result = await _userService.GetUserNameAsync(99);

        // Assert
        Assert.Equal("Not found", result);
        _repoMock.Verify(r => r.GetById(99), Times.Once);
    }

    [Fact]
    public async Task GetUserNameAsync_WithFullUserData_ReturnsName()
    {
        // Arrange - Mock returns full object
        var mockUser = new User
        {
            Id = 1,
            Name = "Sang",
            FirstName = "Nguyen",
            Age = 25,
            CreatedAt = DateTime.Parse("2024-01-01"),
            UpdatedAt = DateTime.Parse("2024-01-15")
        };

        _repoMock.Setup(x => x.GetById(1))
            .ReturnsAsync(mockUser);

        // Act - Service only returns Name
        var result = await _userService.GetUserNameAsync(1);

        // Assert
        Assert.Equal("Sang", result);
        _repoMock.Verify(r => r.GetById(1), Times.Once);
    }

    [Fact]
    public async Task GetUserDetailsAsync_ReturnsFullData()
    {
        // Arrange
        var mockUser = new User
        {
            Id = 1,
            Name = "Sang",
            FirstName = "Nguyen",
            Age = 25,
            CreatedAt = DateTime.Parse("2024-01-01"),
            UpdatedAt = DateTime.Parse("2024-01-15")
        };

        _repoMock.Setup(x => x.GetById(1))
            .ReturnsAsync(mockUser);

        // Act
        var result = await _userService.GetUserDetailsAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Sang", result.Name);
        Assert.Equal("Nguyen", result.FirstName);
        Assert.Equal(25, result.Age);
        Assert.Equal(DateTime.Parse("2024-01-01"), result.CreatedAt);
        Assert.Equal(DateTime.Parse("2024-01-15"), result.UpdatedAt);
        _repoMock.Verify(r => r.GetById(1), Times.Once);
    }

    [Fact]
    public async Task GetUserDetailsAsync_WithInvalidId_ReturnsNull()
    {
        // Arrange
        _repoMock.Setup(x => x.GetById(99))
            .ReturnsAsync((User?)null);

        // Act
        var result = await _userService.GetUserDetailsAsync(99);

        // Assert
        Assert.Null(result);
        _repoMock.Verify(r => r.GetById(99), Times.Once);
    }
}