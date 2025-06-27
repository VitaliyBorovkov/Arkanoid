//using strange.extensions.mediation.impl;

//public class ScoreMediator : Mediator
//{
//    [Inject] public ScoreView scoreView { get; set; }
//    [Inject] public ScoreUpdatedSignal scoreUpdatedSignal { get; set; }

//    public override void OnRegister()
//    {
//        scoreUpdatedSignal.AddListener(OnScoreUpdated);
//    }

//    public override void OnRemove()
//    {
//        scoreUpdatedSignal.RemoveListener(OnScoreUpdated);
//    }

//    public void OnScoreUpdated(int newScore)
//    {
//        scoreView.SetScore(newScore);
//    }
//}
