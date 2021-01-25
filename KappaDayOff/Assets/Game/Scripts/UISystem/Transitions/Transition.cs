using DG.Tweening;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class Transition : MonoBehaviour
{
	[Header("Transition Properties"), SerializeField]
	protected float duration;

	[SerializeField] protected Ease easingStrategy;

	public Tween EntranceTween { get; protected set; }
	public Tween ExitTween     { get; protected set; }


	private void OnDisable()
	{
		this.OnReset();
	}

	public void Intialize()
	{
		this.Setup();
		if (this.easingStrategy == Ease.Unset)
		{
			this.easingStrategy = DOTween.defaultEaseType;
		}

		this.SetupEntrance();
		this.SetupExit();
		this.OnReset();
	}

	public void Deinitialize()
	{
		this.EntranceTween?.Kill();
		this.ExitTween?.Kill();
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