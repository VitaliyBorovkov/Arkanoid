using strange.extensions.injector.api;

using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private BlockSettings blockSettings;

    [SerializeField] private int blockRows = 5;
    [SerializeField] private int blockColumns = 10;
    [SerializeField] private float blockSpacingX = 1.1f;
    [SerializeField] private float blockSpacingY = 0.5f;
    [SerializeField] private Vector2 startPosition = new Vector2(-5f, 3f);

    private IInjector injector;
    private BlockCounterService blockCounterService;

    public void Initialize(IInjector injector, BlockCounterService blockCounterService)
    {
        this.injector = injector;
        this.blockCounterService = blockCounterService;
    }

    public void SpawnBlocks()
    {
        int totalSpawnedBlocks = 0;

        for (int row = 0; row < blockRows; row++)
        {
            for (int col = 0; col < blockColumns; col++)
            {
                Vector2 position = new Vector2(startPosition.x + col * blockSpacingX, startPosition.y - row * blockSpacingY);

                GameObject block = Instantiate(blockPrefab, position, Quaternion.identity, transform);
                BlockView blockView = block.GetComponent<BlockView>();
                if (blockView != null)
                {
                    injector.Inject(blockView);
                    blockView.Initialize(blockSettings);
                    totalSpawnedBlocks++;
                }
            }
        }
        blockCounterService.SetTotalBlocks(totalSpawnedBlocks);
        //Debug.Log($"[BlockSpawner] Spawned {totalSpawnedBlocks} blocks");
    }
}
