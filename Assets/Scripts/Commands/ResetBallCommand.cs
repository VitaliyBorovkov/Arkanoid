using strange.extensions.command.impl;

public class ResetBallCommand : Command
{
    [Inject] public BallView ballView { get; set; }
    [Inject] public PaddleView paddleView { get; set; }

    public override void Execute()
    {
        ballView.ResetBall();
        ballView.AttachToPaddle(paddleView.transform);
    }
}
