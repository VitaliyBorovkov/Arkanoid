using strange.extensions.mediation.impl;

using System;

using UnityEngine;

public class BlockView : View
{
    [SerializeField] private BlockSettings blockSettings;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Inject] public BlockDestroyedSignal blockDestroyedSignal { get; set; }

    public BlockSettings Settings => blockSettings;

    public event Action OnHitEvent;

    public void Initialize(BlockSettings settings)
    {
        blockSettings = settings;
        spriteRenderer.color = blockSettings.blockColor;
    }

    public void Hit()
    {
        OnHitEvent?.Invoke();
    }

    public void DestroyBlock()
    {
        Destroy(gameObject, 0.05f);
    }

}
