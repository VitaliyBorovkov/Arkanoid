public class ScoreModel
{
    public int CurrentScore { get; private set; }

    //public ScoreUpdatedSignal scoreUpdatedSignal;

    //public ScoreModel(ScoreUpdatedSignal scoreUpdatedSignal)
    //{
    //    this.scoreUpdatedSignal = scoreUpdatedSignal;
    //    CurrentScore = 0;
    //}

    public void AddScore(int amount)
    {
        CurrentScore += amount;
        //scoreUpdatedSignal.Dispatch(CurrentScore);
    }

    public void Reset()
    {
        CurrentScore = 0;
        //scoreUpdatedSignal.Dispatch(CurrentScore);
    }
}
