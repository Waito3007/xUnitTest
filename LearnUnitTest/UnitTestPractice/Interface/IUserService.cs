using LearnUnitTest.UnitTestPractice.Model;

namespace LearnUnitTest.UnitTestPractice.Interface;

public interface IUserService
{
    Task<string> GetUserNameAsync(ServerType.ServerRequest id);
    Task<User> GetById(ServerType.ServerRequest id);
}