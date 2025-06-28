using strange.extensions.context.impl;

using UnityEngine;

public class GameSceneStarter : MonoBehaviour
{
    [SerializeField] private Transform levelRoot;

    private void Start()
    {
        var contextView = FindObjectOfType<ContextView>();
        if (contextView == null)
        {
            Debug.LogError("[GameSceneStarter] ContextView not found in scene!");
            return;
        }

        var context = contextView.context as GameContext;
        if (context == null)
        {
            Debug.LogError("[GameSceneStarter] Failed to cast context to GameContext.");
            return;
        }

        var signal = context.injectionBinder.GetInstance<GameSceneStartedSignal>();
        signal.Dispatch();
        Debug.Log("[GameSceneStarter] GameSceneStartedSignal dispatched.");
    }
}
