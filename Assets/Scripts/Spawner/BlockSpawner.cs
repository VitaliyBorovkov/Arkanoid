using strange.extensions.injector.api;

using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private LevelData levelData;
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
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        int totalSpawnedBlocks = 0;

        if (levelData == null || levelData.rows == null)
        {
            Debug.LogError("[BlockSpawner] LevelData is null or empty!");
            return;
        }

        for (int row = 0; row < levelData.rows.Length; row++)
        {
            BlockLayoutRow layoutRow = levelData.rows[row];
            if (layoutRow == null || layoutRow.blocksInRow == null)
                continue;

            for (int col = 0; col < layoutRow.blocksInRow.Length; col++)
            {
                BlockSettings settings = layoutRow.blocksInRow[col];
                if (settings == null) continue;

                Vector2 position = new Vector2(
                    startPosition.x + col * blockSpacingX,
                    startPosition.y - row * blockSpacingY
                );

                GameObject block = Instantiate(blockPrefab, position, Quaternion.identity, transform);
                BlockView blockView = block.GetComponent<BlockView>();
                if (blockView != null)
                {
                    injector.Inject(blockView);
                    blockView.Initialize(settings);
                    totalSpawnedBlocks++;
                }
            }
        }

        blockCounterService.SetTotalBlocks(totalSpawnedBlocks);
        Debug.Log($"[BlockSpawner] Spawned {totalSpawnedBlocks} blocks");
    }
}
