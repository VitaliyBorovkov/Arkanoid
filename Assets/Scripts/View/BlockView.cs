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

        spriteRenderer.color = blockSettings.blockColor;
        spriteRenderer.sprite = blockSettings.blockSprite;
    }

    public void Hit()
    {
        currentHits--;

        if (currentHits <= 0)
        {
            OnHitEvent?.Invoke();
        }
    }

    public void DestroyBlock()
    {
        Destroy(gameObject, 0.05f);
    }

}
