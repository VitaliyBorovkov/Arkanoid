using strange.extensions.context.impl;

public class MenuContextView : ContextView
{
    private void Awake()
    {
        context = new MenuContext(this);
    }
}
