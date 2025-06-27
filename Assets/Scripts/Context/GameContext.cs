using strange.extensions.context.impl;
using strange.extensions.injector.impl;

using UnityEngine;

public class GameContext : MVCSContext
{
    public GameContext(MonoBehaviour view) : base(view)
    {
    }

    protected override void mapBindings()
    {
        //Debug.Log("GameContext.mapBindings called");

        injectionBinder.Bind<LaunchBallSignal>().ToSingleton();
        injectionBinder.Bind<ResetBallSignal>().ToSingleton();
        injectionBinder.Bind<BallLostSignal>().ToSingleton();
        injectionBinder.Bind<BlockDestroyedSignal>().ToSingleton();
        //injectionBinder.Bind<ScoreUpdatedSignal>().ToSingleton();
        injectionBinder.Bind<LivesUpdatedSignal>().ToSingleton();
        injectionBinder.Bind<GameSceneStartedSignal>().ToSingleton();
        injectionBinder.Bind<GameEndedSignal>().ToSingleton();

        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();
        injectionBinder.Bind<BlockCounterService>().To<BlockCounterService>().ToSingleton();
        injectionBinder.Bind<LivesModel>().To<LivesModel>().ToSingleton();

        commandBinder.Bind<BallLostSignal>().To<BallLostCommand>();
        commandBinder.Bind<GameSceneStartedSignal>().To<GameSceneStartedCommand>();

        var paddleView = GameObject.FindObjectOfType<PaddleView>();
        injectionBinder.Bind<PaddleView>().ToValue(paddleView);

        var ballColisionHandler = GameObject.FindObjectOfType<BallCollisionHandler>();
        injectionBinder.Bind<BallCollisionHandler>().ToValue(ballColisionHandler);

        var blockSpawner = GameObject.FindObjectOfType<BlockSpawner>();
        if (blockSpawner == null)
        {
            Debug.LogError("[GameContext] BlockSpawner not found in scene!");
        }
        else
        {

            injectionBinder.Bind<BlockSpawner>().ToValue(blockSpawner);
        }

        var blockCounterService = injectionBinder.GetInstance<BlockCounterService>();
        var concreteBinder = injectionBinder as InjectionBinder;

        blockSpawner.Initialize(concreteBinder.injector, blockCounterService);

        //var scoreView = GameObject.FindObjectOfType<ScoreView>();
        //concreteBinder.injector.Inject(scoreView);

        var endGameView = GameObject.FindObjectOfType<EndGameView>();
        concreteBinder.injector.Inject(endGameView);

        mediationBinder.Bind<EndGameView>().To<EndGameMediator>();
        mediationBinder.Bind<BlockView>().To<BlockMediator>();
        mediationBinder.Bind<BallView>().To<BallMediator>();
        mediationBinder.Bind<PaddleView>().To<PaddleMediator>();
        //mediationBinder.Bind<ScoreView>().To<ScoreMediator>();
        mediationBinder.Bind<IconCounterView>().To<LivesMediator>();
        mediationBinder.Bind<BallCollisionHandler>().ToMediator<NullMediator>();
    }
}
