using strange.extensions.command.impl;

using UnityEngine;

public class QuitGameCommand : Command
{
    public override void Execute()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
