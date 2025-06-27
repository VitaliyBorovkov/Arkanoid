using strange.extensions.mediation.impl;

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallView : View
{
    [SerializeField] private BallSettings ballSettings;

    private Rigidbody2D rb;
    private Transform paddleTransform;
    private bool isAttachedToPaddle = false;

    public event System.Action BallFell;

    public Vector2 CurrentVelocity => rb.velocity;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }

    protected override void Start()
    {
        base.Start();
    }

    private void LateUpdate()
    {
        if (isAttachedToPaddle && paddleTransform != null)
        {
            Vector3 pos = paddleTransform.position;
            pos.y += 0.5f;
            transform.position = pos;
        }
    }

    public void Launch()
    {
        isAttachedToPaddle = false;
        rb.simulated = true;

        float x = Random.Range(ballSettings.MinDirectionX, 1f);
        x *= Random.value > 0.5f ? 1f : -1f;

        Vector2 direction = new Vector2(x, 1f).normalized;

        rb.velocity = direction * ballSettings.Speed;
    }

    public void ResetBall()
    {
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        transform.position = ballSettings.StartPosition;
    }

    public void Reflect(Vector2 direction)
    {
        rb.velocity = direction.normalized * ballSettings.Speed;
    }

    public void Stop()
    {
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        transform.position = ballSettings.StartPosition;
    }

    public void AttachToPaddle(Transform paddle)
    {
        paddleTransform = paddle;
        isAttachedToPaddle = true;
        rb.simulated = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeathZone"))
        {
            BallFell?.Invoke();
        }
    }
}

