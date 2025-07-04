public class BlockCounterService
{
    private int totalBlocks;

    public int RemainingBlocks => totalBlocks;

    public void SetTotalBlocks(int count)
    {
        totalBlocks = count;
    }

    public void OnBlockDestroyed()
    {
        totalBlocks--;
    }

    public bool AreAllBlocksDestroyed()
    {
        return totalBlocks <= 0;
    }
}
