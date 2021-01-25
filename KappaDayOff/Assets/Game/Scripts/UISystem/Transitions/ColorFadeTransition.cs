using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image)), DisallowMultipleComponent]
public class ColorFadeTransition : Transition
{
	[Header("Color Fade Transition Options"), Tooltip("Color before entrance transition."), SerializeField]
	private Color fromColor;

	[Tooltip("Color after entrance transition."), SerializeField]
	private Color toColor;

	private Image image;

	protected override void Setup()
	{
		image = GetComponent<Image>();
	}

	protected override void SetupEntrance()
	{
		EntranceTween = image.DOColor(toColor, duration)
		                     .SetEase(easingStrategy);
	}

	protected override void SetupExit()
	{
		ExitTween = image.DOColor(fromColor, duration)
		                 .SetEase(easingStrategy);
	}

	public override void OnReset()
	{
		image.color = fromColor;
	}
}