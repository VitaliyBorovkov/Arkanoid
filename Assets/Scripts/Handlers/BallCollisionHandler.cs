using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallCollisionHandler : MonoBehaviour
{
    [SerializeField] private BallView ballView;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BlockView blockView = collision.gameObject.GetComponent<BlockView>();
        if (blockView != null)
        {
            blockView.Hit();
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = ballView.CurrentVelocity;

        if (velocity.magnitude < 0.1f)
        {
            Vector2 nudge = new Vector2(Random.Range(-0.5f, 0.5f), 1f).normalized;
            ballView.Reflect(nudge);
            return;
        }

        bool corrected = false;

        if (Mathf.Abs(velocity.x) < 0.1f)
        {
            velocity.x = 0.2f * Mathf.Sign(Random.value - 0.5f);
            corrected = true;
        }

        if (Mathf.Abs(velocity.y) < 0.1f)
        {
            velocity.y = 0.2f * Mathf.Sign(Random.value - 0.5f);
            corrected = true;
        }

        if (corrected)
        {
            ballView.Reflect(velocity);
        }
    }
}
