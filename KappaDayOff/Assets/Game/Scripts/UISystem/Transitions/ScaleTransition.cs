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
		EntranceTween = transform.DOScale(toScale, duration)
		                         .SetEase(easingStrategy);
	}

	protected override void SetupExit()
	{
		ExitTween = transform.DOScale(fromScale, duration)
		                     .SetEase(easingStrategy);
	}

	public override void OnReset()
	{
		gameObject.transform.localScale = fromScale;
	}
}