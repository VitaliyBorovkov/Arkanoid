using strange.extensions.command.impl;

using UnityEngine;

public class GameEndedCommand : Command
{
    [Inject] public GameResult gameResult { get; set; }
    [Inject] public LevelLoader levelLoader { get; set; }

    public override void Execute()
    {
        var endGameView = GameObject.FindObjectOfType<EndGameView>();
        if (endGameView == null)
        {
            Debug.LogError("[GameEndedCommand] EndGameView not found in scene!");
            return;
        }


        if (gameResult.IsWin)
        {
            Debug.Log("[GameEndedCommand] Victory — loading next level...");
            levelLoader.LoadNextLevel();
        }

        endGameView.ShowEndScreen(gameResult);
    }
}