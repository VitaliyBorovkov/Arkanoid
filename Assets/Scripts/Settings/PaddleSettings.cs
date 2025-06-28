using UnityEngine;

[CreateAssetMenu(fileName = "PaddleSettings", menuName = "Settings/Paddle Settings")]
public class PaddleSettings : ScriptableObject
{
    public float moveSpeed = 10f;
    public float smoothFactor = 5f;
}
