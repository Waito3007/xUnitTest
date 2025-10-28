using LearnUnitTest.UnitTestPractice.Interface;
using LearnUnitTest.UnitTestPractice.Model;

namespace LearnUnitTest.UnitTestPractice;

public class UserService: IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<string> GetUserNameAsync(int id)
    {
        var user = await _repo.GetById(id);
        return user?.Name ?? "Not found";
    }

    public async Task<User?> GetById(int id)
    {
        var user = await _repo.GetById(id);
        return user;
    }

    public async Task<User?> GetUserDetailsAsync(int id)
    {
        var user = await _repo.GetById(id);
        return user;
    }
}