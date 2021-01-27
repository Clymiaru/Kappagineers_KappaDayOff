using DG.Tweening;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class ViewAnimation : MonoBehaviour
{
	[Header("Transition Properties"), SerializeField]
	protected float duration;

	[SerializeField] protected Ease easingStrategy;

	public Tween EntranceTween { get; protected set; }
	public Tween ExitTween     { get; protected set; }


	private void OnDisable()
	{
		OnReset();
	}

	public void Intialize()
	{
		Setup();
		if (easingStrategy == Ease.Unset)
		{
			easingStrategy = DOTween.defaultEaseType;
		}

		SetupEntrance();
		SetupExit();
		OnReset();
	}

	public void Deinitialize()
	{
		EntranceTween?.Kill();
		ExitTween?.Kill();
	}

	protected virtual void Setup()
	{
	}

	protected virtual void SetupEntrance()
	{
	}

	protected virtual void SetupExit()
	{
	}

	public abstract void OnReset();
}
