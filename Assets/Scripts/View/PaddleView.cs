using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PaddleView : MonoBehaviour
{
    [SerializeField] private PaddleSettings paddleSettings;

    private Rigidbody2D rb;

    private float minX;
    private float maxX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        float halfWidth = transform.localScale.x / 2f;
        float screenHalfHeight = Camera.main.aspect * Camera.main.orthographicSize;

        minX = -screenHalfHeight + halfWidth;
        maxX = screenHalfHeight - halfWidth;
    }

    private void Update()
    {
#if UNITY_EDITOR
        float input = Input.GetAxisRaw("Horizontal");
        MoveByInput(input);
#else
        if (Input.touchCount > 0)
	{
        FollowFinger(Input.GetTouch(0));
	}
#endif
    }

#if UNITY_EDITOR
    private void MoveByInput(float input)
    {
        float targetX = Mathf.Clamp(rb.position.x + input * paddleSettings.moveSpeed, minX, maxX);

        float smoothSpeed = paddleSettings.moveSpeed * paddleSettings.smoothFactor;
        float newX = Mathf.Lerp(rb.position.x, targetX, Time.deltaTime * smoothSpeed);

        rb.MovePosition(new Vector2(targetX, rb.position.y));
    }
#else
    private void FollowFinger(Touch touch)
    {
        Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);
        float clampedX = Mathf.Clamp(touchWorldPos.x, paddleSettings.minX, paddleSettings.maxX);

        float smoothSpeed = paddleSettings.moveSpeed * paddleSettings.smoothFactor;
        float newX = Mathf.Lerp(rb.position.x, clampedX, Time.deltaTime * smoothSpeed);

        rb.MovePosition(new Vector2(newX, rb.position.y));
    }
#endif


}
