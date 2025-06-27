using UnityEngine;

[CreateAssetMenu(fileName = "BallSettings", menuName = "Settings/Ball Settings")]
public class BallSettings : ScriptableObject
{
    [Range(0.3f, 1f)]
    public float MinDirectionX = 0.3f;

    public float Speed = 5f;
    public Vector2 StartPosition = new Vector2(0f, -3.5f);
}
