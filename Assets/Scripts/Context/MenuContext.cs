using strange.extensions.context.impl;

using UnityEngine;

public class MenuContext : MVCSContext
{
    public MenuContext(MonoBehaviour view) : base(view)
    {
    }

    protected override void mapBindings()
    {
        //Debug.Log("MenuContext.mapBindings called");
        injectionBinder.Bind<StartGameSignal>().ToSingleton();
        commandBinder.Bind<StartGameSignal>().To<StartGameCommand>();

        injectionBinder.Bind<QuitGameSignal>().ToSingleton();
        commandBinder.Bind<QuitGameSignal>().To<QuitGameCommand>();

        mediationBinder.Bind<MenuView>().To<MenuMediator>();
    }
}
