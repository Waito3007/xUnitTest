using LearnUnitTest.UnitTestPractice.Model;

namespace LearnUnitTest.UnitTestPractice.Interface;

public interface IUserRepository
{
    Task<User?>  GetById(int id);
}

