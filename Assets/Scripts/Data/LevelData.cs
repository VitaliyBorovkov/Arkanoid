using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data")]
public class LevelData : ScriptableObject
{
    public BlockLayoutRow[] rows;
}

[System.Serializable]
public class BlockLayoutRow
{
    public BlockSettings[] blocksInRow;
}