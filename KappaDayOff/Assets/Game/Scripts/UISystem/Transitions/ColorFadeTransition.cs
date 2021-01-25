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
		this.image = this.GetComponent<Image>();
	}

	protected override void SetupEntrance()
	{
		this.EntranceTween = this.image.DOColor(this.toColor, this.duration)
		                         .SetEase(this.easingStrategy);
	}

	protected override void SetupExit()
	{
		this.ExitTween = this.image.DOColor(this.fromColor, this.duration)
		                     .SetEase(this.easingStrategy);
	}

	public override void OnReset()
	{
		this.image.color = this.fromColor;
	}
}
