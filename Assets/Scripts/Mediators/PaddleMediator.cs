using strange.extensions.mediation.impl;

using UnityEngine;

public class PaddleMediator : Mediator
{
    [Inject] public PaddleView view { get; set; }

    public override void OnRegister()
    {
        Debug.Log("PaddleMediator registered");
    }

    public override void OnRemove()
    {
        Debug.Log("BallMediator removed");
    }
}
