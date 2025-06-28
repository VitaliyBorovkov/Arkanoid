using UnityEngine;

[CreateAssetMenu(fileName = "BlockSettings", menuName = "Settings/Block Settings")]
public class BlockSettings : ScriptableObject
{
    public int score = 100;
    public int hitPoints = 1;
    public Sprite blockSprite;
    public Sprite[] damagedSprites;
}
