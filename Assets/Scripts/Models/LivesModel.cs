public class LivesModel
{
    public int CurrentLives { get; private set; } = 3;
    public int MaxLives { get; private set; } = 3;

    public void Initialize(int maxLives)
    {
        MaxLives = maxLives;
        CurrentLives = maxLives;
    }

    public void LooseLife()
    {
        if (CurrentLives > 0)
        {
            CurrentLives--;
        }
    }

    public bool HasLives()
    {
        return CurrentLives > 0;
    }
}
