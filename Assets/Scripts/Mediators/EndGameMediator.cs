using strange.extensions.mediation.impl;

using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMediator : Mediator
{
    [Inject] public EndGameView view { get; set; }
    //[Inject] public GameEndedSignal gameEndedSignal { get; set; }

    public override void OnRegister()
    {
        //Debug.Log("EndGameMediator: Registered");

        //gameEndedSignal.AddListener(OnGameEnded);

        view.RepeatButton.onClick.AddListener(OnRepeatButtonClicked);
        view.ExitToMenuButton.onClick.AddListener(OnExitToMenuButtonClicked);
    }

    public override void OnRemove()
    {
        Debug.Log("EndGameMediator: Removed");
        //gameEndedSignal.RemoveListener(OnGameEnded);

        view.RepeatButton.onClick.RemoveListener(OnRepeatButtonClicked);
        view.ExitToMenuButton.onClick.RemoveListener(OnExitToMenuButtonClicked);
    }

    //private void OnGameEnded(GameResult gameResult)
    //{
    //    view.ShowEndScreen(gameResult);

    //    if (gameResult.IsWin)
    //    {
    //        view.StartCoroutine(WaitAndLoadNextLevel());
    //    }
    //}

    //private IEnumerator WaitAndLoadNextLevel()
    //{
    //    yield return null;
    //    yield return new WaitForSecondsRealtime(5f);

    //    Time.timeScale = 1f;
    //    levelLoader.LoadNextLevel();
    //}

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
