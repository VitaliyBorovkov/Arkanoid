using strange.extensions.mediation.impl;

using System;

using UnityEngine;

public class BlockView : View
{
    [SerializeField] private BlockSettings blockSettings;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Inject] public BlockDestroyedSignal blockDestroyedSignal { get; set; }

    public BlockSettings Settings => blockSettings;
    private int currentHits;

    public event Action OnHitEvent;

    public void Initialize(BlockSettings settings)
    {
        blockSettings = settings;
        currentHits = settings.hitPoints;

        spriteRenderer.sprite = blockSettings.blockSprite;
    }

    public void Hit()
    {
        currentHits--;

        if (currentHits <= 0)
        {
            OnHitEvent?.Invoke();
        }
        else
        {
            UpdateVisual();
        }
    }

    private void UpdateVisual()
    {
        int damageIndex = blockSettings.hitPoints - currentHits - 1;

        if (blockSettings.damagedSprites != null &&
            damageIndex >= 0 &&
            damageIndex < blockSettings.damagedSprites.Length &&
            blockSettings.damagedSprites[damageIndex] != null)
        {
            spriteRenderer.sprite = blockSettings.damagedSprites[damageIndex];
        }
    }

    public void DestroyBlock()
    {
        Destroy(gameObject, 0.05f);
    }

}
