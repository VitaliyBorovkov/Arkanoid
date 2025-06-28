using UnityEngine;

[CreateAssetMenu(fileName = "BlockSettings", menuName = "Settings/Block Settings")]
public class BlockSettings : ScriptableObject
{
    public int score = 100;
    public Color blockColor = Color.white;
    public int hitPoints = 1;
    public Sprite blockSprite;
}
