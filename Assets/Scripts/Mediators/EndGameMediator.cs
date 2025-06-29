using strange.extensions.mediation.impl;

using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMediator : Mediator
{
    [Inject] public EndGameView view { get; set; }
    [Inject] public GameEndedSignal gameEndedSignal { get; set; }
    [Inject] public ResetBallSignal resetBallSignal { get; set; }
    [Inject] public LevelLoader levelLoader { get; set; }

    public override void OnRegister()
    {
        //Debug.Log("EndGameMediator: Registered");

        gameEndedSignal.AddListener(OnGameEnded);

        view.RepeatButton.onClick.AddListener(OnRepeatButtonClicked);
        view.ExitToMenuButton.onClick.AddListener(OnExitToMenuButtonClicked);
    }

    public override void OnRemove()
    {
        Debug.Log("EndGameMediator: Removed");
        gameEndedSignal.RemoveListener(OnGameEnded);

        view.RepeatButton.onClick.RemoveListener(OnRepeatButtonClicked);
        view.ExitToMenuButton.onClick.RemoveListener(OnExitToMenuButtonClicked);
    }

    private void OnGameEnded(GameResult gameResult)
    {
        view.ShowEndScreen(gameResult);

        if (gameResult.IsWin)
        {
            view.StartCoroutine(AutoHideEndScreen());
        }
    }

    private IEnumerator AutoHideEndScreen()
    {
        yield return new WaitForSecondsRealtime(5f);

        if (!levelLoader.HasNextLevel())
        {
            Debug.Log("[EndGameMediator] Last level reached — not hiding win screen.");
            yield break; // выходим, не скрывая экран и не грузим новый уровень
        }

        view.HideEndScreen();

        Time.timeScale = 1f;
        resetBallSignal.Dispatch();
    }

    private void OnRepeatButtonClicked()
    {
        Debug.Log("EndGameMediator: Repeat button clicked");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnExitToMenuButtonClicked()
    {
        Debug.Log("EndGameMediator: Exit to menu button clicked");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}
