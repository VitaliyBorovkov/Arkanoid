using strange.extensions.mediation.impl;

using UnityEngine;

public class BlockMediator : Mediator
{
    [Inject] public BlockView view { get; set; }
    [Inject] public BlockDestroyedSignal blockDestroyedSignal { get; set; }
    [Inject] public ScoreModel scoreModel { get; set; }
    [Inject] public GameEndedSignal gameEndedSignal { get; set; }
    [Inject] public BlockCounterService blockCounterService { get; set; }
    [Inject] public LivesModel livesModel { get; set; }

    public override void OnRegister()
    {
        view.Initialize(view.Settings);
        view.OnHitEvent += OnHit;
    }

    public override void OnRemove()
    {
        //Debug.Log("[BlockMediator] OnRemove called");
        view.OnHitEvent -= OnHit;
    }

    private void OnHit()
    {
        //Debug.Log("[BlockMediator] OnHit called");
        if (scoreModel == null)
        {
            Debug.LogError("[BlockMediator] scoreModel is NULL!");
        }
        else
        {
            scoreModel.AddScore(view.Settings.score);
            blockDestroyedSignal.Dispatch(view.Settings.score);

            blockCounterService.OnBlockDestroyed();
            if (blockCounterService.AreAllBlocksDestroyed())
            {
                gameEndedSignal.Dispatch(new GameResult(true, scoreModel.CurrentScore, livesModel.CurrentLives));
            }

            view.DestroyBlock();
        }
    }
}
