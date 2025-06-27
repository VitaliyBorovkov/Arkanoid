using strange.extensions.mediation.impl;

public class LivesMediator : Mediator
{
    [Inject] public IconCounterView view { get; set; }
    [Inject] public LivesUpdatedSignal livesUpdatedSignal { get; set; }
    [Inject] public LivesModel livesModel { get; set; }

    public override void OnRegister()
    {
        view.Initialize(livesModel.MaxLives);
        view.SetCount(livesModel.CurrentLives);
        livesUpdatedSignal.AddListener(OnLivesChanged);
    }

    public override void OnRemove()
    {
        livesUpdatedSignal.RemoveListener(OnLivesChanged);
    }

    private void OnLivesChanged(int value)
    {
        view.SetCount(value);
    }
}
