using DG.Tweening;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UIButtonsAnimator : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;
    [SerializeField] private float moveOffseY = 150f;
    [SerializeField] private float duration = 0.4f;
    [SerializeField] private float delayBetweenButtons = 0.15f;
    [SerializeField] private float startDelay = 0.3f;
    [SerializeField] private Ease ease = Ease.OutBack;

    private List<Vector3> initialPositions = new List<Vector3>();
    private bool isInitialized = false;

    public void AnimateButtons()
    {
        Debug.Log("[UIButtonsAnimator] AnimateButtons called");

        if (!isInitialized)
        {
            InitializePositions();
            Debug.Log("[UIButtonsAnimator] Initialized positions");
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            var btn = buttons[i];
            var targetY = initialPositions[i].y;

            if (btn == null)
            {
                continue;
            }

            Debug.Log($"[UIButtonsAnimator] Animate {btn.name}, active={btn.gameObject.activeInHierarchy}");

            btn.transform.DOKill();

            btn.transform.localPosition -= new Vector3(0f, moveOffseY, 0f);
            btn.interactable = false;

            btn.transform.DOLocalMoveY(targetY, duration)
                .SetDelay(startDelay + delayBetweenButtons * i)
                .SetEase(ease)
                .OnComplete(() =>
                {
                    btn.interactable = true;
                    //Debug.Log($"[UIButtonsAnimator] {btn.name} animation complete");
                });
        }
    }

    private void InitializePositions()
    {
        initialPositions.Clear();

        foreach (var btn in buttons)
        {
            if (btn == null)
                continue;

            initialPositions.Add(btn.transform.localPosition);
        }

        isInitialized = true;
    }
}