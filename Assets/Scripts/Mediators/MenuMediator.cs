using strange.extensions.mediation.impl;

public class MenuMediator : Mediator
{
    [Inject] public MenuView view { get; set; }
    [Inject] public StartGameSignal startGameSignal { get; set; }
    [Inject] public QuitGameSignal quitGameSignal { get; set; }
    public UIButtonsAnimator buttonsAnimator { get; set; }

    public override void OnRegister()
    {
        //Debug.Log("[MenuMediator] OnRegister called");
        var buttonsAnimator = view.ButtonsAnimator;
        buttonsAnimator.AnimateButtons();
        view.PlayButton.onClick.AddListener(OnPlayButtonClicked);
        view.ExitButton.onClick.AddListener(OnExitButtonClicked);

    }

    public override void OnRemove()
    {

        view.PlayButton.onClick.RemoveListener(OnPlayButtonClicked);
        view.ExitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        //Debug.Log("[MenuMediator] OnPlayButtonClicked called");
        startGameSignal.Dispatch();
    }

    private void OnExitButtonClicked()
    {
        quitGameSignal.Dispatch();
    }
}
