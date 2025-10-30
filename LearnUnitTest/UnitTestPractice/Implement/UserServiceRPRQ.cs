using LearnUnitTest.UnitTestPractice.Interface;
using LearnUnitTest.UnitTestPractice.Model;
namespace LearnUnitTest.UnitTestPractice.Implement;

public class UserServiceRPRQ : IUserServiceRPRQ
{
    private readonly IUserRepository _userRepository;

    public UserServiceRPRQ(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    
    public async Task<ServerType.ServerResponse> GetServerWithResponseRequest(ServerType.ServerRequest request)
    {
        var account = await _userRepository.GetById(request);
        var response = new ServerType.ServerResponse
        {
            Id = account.Id,
            Name = account.Name
        };
        return response;
    }
}