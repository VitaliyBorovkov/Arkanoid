using strange.extensions.command.impl;

public class BallLostCommand : Command
{
    [Inject] public LivesModel livesModel { get; set; }
    [Inject] public LivesUpdatedSignal livesUpdatedSignal { get; set; }
    [Inject] public ResetBallSignal resetBallSignal { get; set; }
    [Inject] public GameEndedSignal gameEndedSignal { get; set; }
    [Inject] public ScoreModel scoreModel { get; set; }

    public override void Execute()
    {
        livesModel.LooseLife();
        livesUpdatedSignal.Dispatch(livesModel.CurrentLives);

        if (livesModel.HasLives())
        {
            resetBallSignal.Dispatch();
        }
        else
        {
            var result = new GameResult
            {
                IsWin = false,
                Score = scoreModel.CurrentScore
            };
            gameEndedSignal.Dispatch(result);
        }
    }
}
