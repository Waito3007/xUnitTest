namespace LearnUnitTest.UnitTestPractice.Model;

public class ServerType
{
    public class ServerRequest
    {
        public int Id { get; set; }

        public void Validate()
        {
            if (Id == 0)
            {
                throw new ExceptionProject(ResponceEnum.Exception);
            }
        }
    }
    
    public class ServerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}