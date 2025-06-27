using strange.extensions.mediation.impl;

using System.Collections;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class EndGameView : View
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text yourScoreText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Image avatarImage;
    [SerializeField] private Image sunshineImage;
    [SerializeField] private Sprite winSprite;
    [SerializeField] private Sprite loseSprite;
    [SerializeField] private Button repeatButton;
    [SerializeField] private Button exitToMenuButton;
    [SerializeField] private GameObject sunshineObject;
    [SerializeField] private GameObject starsContainer;
    [SerializeField] private IconCounterView starsView;
    [SerializeField] private CanvasGroup livesGroup;
    [SerializeField] private SunshineRotator sunshineRotator;

    public Button RepeatButton => repeatButton;
    public Button ExitToMenuButton => exitToMenuButton;

    public void ShowEndScreen(GameResult gameResult)
    {
        titleText.text = gameResult.IsWin ? "COMPLETE" : "GAME OVER";
        yourScoreText.text = "YOU SCORE: ";

        scoreText.text = gameResult.Score.ToString();
        avatarImage.sprite = gameResult.IsWin ? winSprite : loseSprite;

        sunshineObject.SetActive(gameResult.IsWin);
        starsContainer.SetActive(gameResult.IsWin);

        if (gameResult.IsWin)
        {
            starsView.Initialize(3);
            starsView.SetCount(gameResult.RemainingLives);
        }

        if (livesGroup != null)
        {
            livesGroup.alpha = 0f;
            livesGroup.interactable = false;
            livesGroup.blocksRaycasts = false;
        }

        var canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        sunshineRotator.StartRotation();
        StartCoroutine(DelayPauseGame());
    }

    private IEnumerator DelayPauseGame()
    {
        yield return null;

        Time.timeScale = 0f;
    }
}
