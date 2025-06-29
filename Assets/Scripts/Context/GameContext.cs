using strange.extensions.context.impl;
using strange.extensions.injector.impl;

using UnityEngine;

public class GameContext : MVCSContext
{
    private readonly Transform levelRoot;

    public GameContext(MonoBehaviour view, Transform levelRoot) : base(view)
    {
        this.levelRoot = levelRoot;
    }

    protected override void mapBindings()
    {
        injectionBinder.Bind<LaunchBallSignal>().ToSingleton();
        injectionBinder.Bind<ResetBallSignal>().ToSingleton();
        injectionBinder.Bind<BallLostSignal>().ToSingleton();
        injectionBinder.Bind<BlockDestroyedSignal>().ToSingleton();
        injectionBinder.Bind<LivesUpdatedSignal>().ToSingleton();
        injectionBinder.Bind<GameSceneStartedSignal>().ToSingleton();
        injectionBinder.Bind<GameEndedSignal>().ToSingleton();

        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();
        injectionBinder.Bind<BlockCounterService>().To<BlockCounterService>().ToSingleton();
        injectionBinder.Bind<LivesModel>().To<LivesModel>().ToSingleton();

        commandBinder.Bind<BallLostSignal>().To<BallLostCommand>();
        commandBinder.Bind<GameSceneStartedSignal>().To<GameSceneStartedCommand>();
        commandBinder.Bind<GameEndedSignal>().To<GameEndedCommand>();

        var paddleView = GameObject.FindObjectOfType<PaddleView>();
        injectionBinder.Bind<PaddleView>().ToValue(paddleView);

        var ballColisionHandler = GameObject.FindObjectOfType<BallCollisionHandler>();
        injectionBinder.Bind<BallCollisionHandler>().ToValue(ballColisionHandler);

        var blockCounterService = injectionBinder.GetInstance<BlockCounterService>();
        var concreteBinder = injectionBinder as InjectionBinder;
        var levelLoader = new LevelLoader(levelRoot, concreteBinder.injector, injectionBinder.GetInstance<BlockCounterService>());
        injectionBinder.Bind<LevelLoader>().ToValue(levelLoader);

        mediationBinder.Bind<EndGameView>().To<EndGameMediator>();
        mediationBinder.Bind<BlockView>().To<BlockMediator>();
        mediationBinder.Bind<BallView>().To<BallMediator>();
        mediationBinder.Bind<PaddleView>().To<PaddleMediator>();
        mediationBinder.Bind<IconCounterView>().To<LivesMediator>();
        mediationBinder.Bind<BallCollisionHandler>().ToMediator<NullMediator>();
    }
}
