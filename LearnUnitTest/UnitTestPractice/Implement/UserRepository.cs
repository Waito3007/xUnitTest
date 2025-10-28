using LearnUnitTest.UnitTestPractice.Model;

namespace LearnUnitTest.UnitTestPractice.Interface;

public class UserRepository :IUserRepository
{
    private readonly List<User> user = new()
    {
        new User { Id = 1, Name = "Sang" },
        new User { Id = 2, Name = "Vu" },
        new User { Id = 3, Name = "Yu" }
    };

    public async Task<User?>  GetById(int id)
    {
        var result =  user.FirstOrDefault(u => u.Id == id);
        return result;
    }
}