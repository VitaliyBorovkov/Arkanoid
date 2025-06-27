using strange.extensions.mediation.impl;

using UnityEngine;

public class BallMediator : Mediator
{
    [Inject] public BallView ballView { get; set; }
    [Inject] public PaddleView paddleView { get; set; }
    [Inject] public ScoreModel scoreModel { get; set; }
    [Inject] public LaunchBallSignal launchBallSignal { get; set; }
    [Inject] public ResetBallSignal resetBallSignal { get; set; }
    [Inject] public BallLostSignal ballLostSignal { get; set; }
    [Inject] public GameEndedSignal gameEndedSignal { get; set; }

    private Camera mainCamera;

    private bool ballLaunched = false;

    private void Update()
    {
        if (!ballLaunched && IsLaunchInputReceived())
        {
            ballLaunched = true;
            Debug.Log("Ball launched!");
            launchBallSignal.Dispatch();
        }
    }

    public override void OnRegister()
    {
        //Debug.Log("BallMediator registered");
        mainCamera = Camera.main;

        ballView.BallFell += OnBallLost;

        ballView.AttachToPaddle(paddleView.transform);
        launchBallSignal.AddListener(OnLaunchBall);
        resetBallSignal.AddListener(OnResetBall);
    }

    public override void OnRemove()
    {
        //Debug.Log("BallMediator removed");
        ballView.BallFell -= OnBallLost;

        launchBallSignal.RemoveListener(OnLaunchBall);
        resetBallSignal.RemoveListener(OnResetBall);
    }

    private void OnLaunchBall()
    {
        ballView.Launch();
    }

    private void OnResetBall()
    {
        //Debug.Log("Resetting ball position");
        ballView.ResetBall();
        ballView.AttachToPaddle(paddleView.transform);
        ballLaunched = false;
    }

    private void OnBallLost()
    {
        //Debug.Log("Ball lost!");
        ballLaunched = false;
        ballView.ResetBall();
        ballView.AttachToPaddle(paddleView.transform);
        ballLostSignal.Dispatch();
    }

    private bool IsLaunchInputReceived()
    {
#if UNITY_EDITOR
        return Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);
#else
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
#endif
    }
}
