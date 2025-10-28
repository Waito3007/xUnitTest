using LearnUnitTest.UnitTestPractice.Model;

namespace LearnUnitTest.UnitTestPractice.Interface;

public interface IUserService
{
    Task<string> GetUserNameAsync(int id);
    Task<User> GetById(int id);
}