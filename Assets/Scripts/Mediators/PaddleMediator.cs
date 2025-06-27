using strange.extensions.mediation.impl;

using UnityEngine;

public class PaddleMediator : Mediator
{
    public override void OnRegister()
    {
        Debug.Log("BallMediator registered");
    }

    public override void OnRemove()
    {
        Debug.Log("BallMediator removed");
    }
}
