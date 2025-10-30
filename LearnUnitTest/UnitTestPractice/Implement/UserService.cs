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
    
    public async Task<string> GetUserNameAsync(ServerType.ServerRequest id)
    {
        var user = await _repo.GetById(id);
        return user?.Name ?? "Not found";
    }

    public async Task<User> GetById(ServerType.ServerRequest id)
    {
        var user = await _repo.GetById(id);
        return user;
    }
    
}