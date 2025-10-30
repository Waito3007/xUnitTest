using LearnUnitTest.UnitTestPractice.Model;
namespace LearnUnitTest.UnitTestPractice.Interface;

public interface IUserServiceRPRQ
{
    Task<ServerType.ServerResponse> GetServerWithResponseRequest(ServerType.ServerRequest request);
}