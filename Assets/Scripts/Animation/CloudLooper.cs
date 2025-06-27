using DG.Tweening;

using UnityEngine;

public class CloudLooper : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1500f;
    [SerializeField] private float moveDuration = 10f;

    private RectTransform rectTransform;
    private Vector2 initialStartPosition;
    private Sequence cloudSequence;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        initialStartPosition = rectTransform.anchoredPosition;

        rectTransform.anchoredPosition = new Vector2(initialStartPosition.x - moveDistance, initialStartPosition.y);
    }

    private void Start()
    {
        Loop();
    }

    private void Loop()
    {
        cloudSequence = DOTween.Sequence();
        cloudSequence.AppendCallback(() =>
        {
            rectTransform.anchoredPosition = new Vector2(initialStartPosition.x - moveDistance, initialStartPosition.y);
        });

        cloudSequence.Append(rectTransform.DOAnchorPosX(initialStartPosition.x + moveDistance, moveDuration)
            .SetEase(Ease.Linear));

        cloudSequence.SetLoops(-1);
    }

    private void OnDestroy()
    {
        cloudSequence?.Kill();
    }
}
