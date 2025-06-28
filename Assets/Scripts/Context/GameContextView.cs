using strange.extensions.context.impl;

using UnityEngine;

public class GameContextView : ContextView
{
    private void Awake()
    {
        Debug.Log("[GameContextView] Awake");
        context = new GameContext(this, transform);
    }
}
