using strange.extensions.injector.api;

using UnityEngine;

public class LevelLoader
{
    private readonly Transform levelRoot;
    private readonly IInjector injector;
    private readonly BlockCounterService blockCounterService;

    private GameObject currentLevel;
    private int currentLevelIndex = 1;

    public LevelLoader(Transform levelRoot, IInjector injector, BlockCounterService blockCounterService)
    {
        this.levelRoot = levelRoot;
        this.injector = injector;
        this.blockCounterService = blockCounterService;
    }

    public void LoadLevel(int levelIndex)
    {
        if (currentLevel != null)
        {
            Object.Destroy(currentLevel);
        }

        string path = $"Levels/Level{levelIndex}";
        GameObject levelPrefab = Resources.Load<GameObject>(path);
        if (levelPrefab == null)
        {
            Debug.LogError($"[LevelLoader] Level prefab not found: {path}");
            return;
        }

        currentLevel = Object.Instantiate(levelPrefab, levelRoot);
        Debug.Log($"[LevelLoader] Loaded: Level{levelIndex}");

        BlockView[] blocks = currentLevel.GetComponentsInChildren<BlockView>();
        foreach (BlockView block in blocks)
        {
            injector.Inject(block);
            block.Initialize(block.Settings);
        }

        blockCounterService.SetTotalBlocks(blocks.Length);
        currentLevelIndex = levelIndex;
    }

    public void LoadNextLevel()
    {
        LoadLevel(currentLevelIndex + 1);
    }
}
