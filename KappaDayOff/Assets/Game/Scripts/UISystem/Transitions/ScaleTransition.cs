using DG.Tweening;
using UnityEngine;

[DisallowMultipleComponent]
public class ScaleTransition : Transition
{
	[Header("Scale Transition Options"), Tooltip("Scale vector of the game object before entrance transition."), SerializeField]
	private Vector3 fromScale;

	[Tooltip("Scale vector of the game object after entrance transition."), SerializeField]
	private Vector3 toScale;

	protected override void Setup()
	{
	}

	protected override void SetupEntrance()
	{
		this.EntranceTween = this.transform.DOScale(this.toScale, this.duration)
		                         .SetEase(this.easingStrategy);
	}

	protected override void SetupExit()
	{
		this.ExitTween = this.transform.DOScale(this.fromScale, this.duration)
		                     .SetEase(this.easingStrategy);
	}

	public override void OnReset()
	{
		this.gameObject.transform.localScale = this.fromScale;
	}
}