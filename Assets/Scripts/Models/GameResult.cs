public struct GameResult
{
    public bool IsWin;
    public int Score;
    public int RemainingLives;

    public GameResult(bool isWin, int score, int remainingLives)
    {
        IsWin = isWin;
        Score = score;
        RemainingLives = remainingLives;

    }
}
