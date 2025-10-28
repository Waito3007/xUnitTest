namespace LearnUnitTest.UnitTestPractice;

public class ScoreService
{
    public int avgScore(int[] scores)
    {
        int total = 0; 
        for (int i = 0; i < scores.Length; i++)
        {
            int score = scores[i];
            if (score < 0 || score > 10000)
            {
                throw new ArgumentException("Score out of range");
            } 
            
            total += score ;
        }
        return total / scores.Length;
    }
}