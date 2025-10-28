namespace LearnUnitTest.UnitTestPractice.Model;

public class User 
{ 
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string FirstName { get; set; } = "";
    public int Age { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}