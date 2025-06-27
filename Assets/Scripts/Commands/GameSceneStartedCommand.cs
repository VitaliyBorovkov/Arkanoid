using strange.extensions.command.impl;
using strange.extensions.injector.api;

public class GameSceneStartedCommand : Command
{
    [Inject] public BlockSpawner blockSpawner { get; set; }
    [Inject] public BlockCounterService blockCounterService { get; set; }
    [Inject] public new IInjectionBinder injectionBinder { get; set; }
    [Inject] public ScoreModel scoreModel { get; set; }
    [Inject] public LivesModel livesModel { get; set; }
    [Inject] public LivesUpdatedSignal livesUpdatedSignal { get; set; }

    public override void Execute()
    {
        IInjector injector = injectionBinder.injector;

        blockSpawner.Initialize(injector, blockCounterService);
        blockSpawner.SpawnBlocks();

        scoreModel.Reset();

        livesModel.Initialize(3);
        livesUpdatedSignal.Dispatch(livesModel.CurrentLives);

        //Debug.Log("[GameSceneStartedCommand] Game scene initialized.");
    }
}
