public class ScoreModel
{
    public int CurrentScore { get; private set; }

    public void AddScore(int amount)
    {
        CurrentScore += amount;
    }

    public void Reset()
    {
        CurrentScore = 0;
    }
}
