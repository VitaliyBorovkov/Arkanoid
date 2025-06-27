using strange.extensions.mediation.impl;

using UnityEngine;
using UnityEngine.UI;

public class MenuView : View
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private UIButtonsAnimator buttonsAnimator;

    public Button PlayButton => playButton;
    public Button ExitButton => exitButton;
    public UIButtonsAnimator ButtonsAnimator => buttonsAnimator;
}