using strange.extensions.context.impl;

public class GameContextView : ContextView
{
    private void Awake()
    {
        context = new GameContext(this);
    }
}
