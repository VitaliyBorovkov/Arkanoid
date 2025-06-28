using DG.Tweening;

using UnityEngine;

public class SunshineRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private RotationMode mode = RotationMode.DOTween;

    private bool isRotating = false;

    private void Start()
    {
        if (mode == RotationMode.DOTween)
        {
            StartDOTween();
        }
    }

    private void Update()
    {
        if (mode != RotationMode.Manual || !isRotating)
        {
            return;
        }

        transform.localEulerAngles += new Vector3(0f, 0f, rotationSpeed * Time.unscaledDeltaTime);
    }

    public void StartRotation()
    {
        isRotating = true;

        if (mode == RotationMode.DOTween)
        {
            StartDOTween();
        }
    }

    public void StartDOTween()
    {
        //Debug.Log($"[SunshineRotator] StartDOTween called on: {gameObject.name}");

        transform.DORotate(new Vector3(0f, 0f, -360f), rotationSpeed, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }
}
