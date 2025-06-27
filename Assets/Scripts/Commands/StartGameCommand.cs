using strange.extensions.command.impl;

using UnityEngine.SceneManagement;

public class StartGameCommand : Command
{
    public override void Execute()
    {
        SceneManager.LoadScene("GameScene");
    }
}
