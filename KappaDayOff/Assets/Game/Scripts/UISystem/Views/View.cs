using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct TransitionInfo
{
	public float      StartTime;
	public Transition Transition;
}

public class View : MonoBehaviour
{
	[Header("Transitions"), SerializeField]
	private List<TransitionInfo> transitions = new List<TransitionInfo>();

	private   Sequence entranceSequence;
	private   Sequence exitSequence;
	protected Action   OnEnterEnd;

	protected Action OnEnterStart;
	protected Action OnExitEnd;
	protected Action OnExitStart;

	protected bool isFocused = false;

	private List<Selectable> selectables = new List<Selectable>();

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) &&
		    this.isFocused)
		{
			this.OnBackPressed();
		}
	}

	public void Initialize()
	{
		this.GetSelectables();
		if (this.transitions.Count > 0)
		{
			this.entranceSequence = DOTween.Sequence().SetAutoKill(false);
			this.exitSequence     = DOTween.Sequence().SetAutoKill(false);
			foreach (TransitionInfo transitionInfo in this.transitions)
			{
				transitionInfo.Transition.Intialize();
				this.entranceSequence.Insert(transitionInfo.StartTime, transitionInfo.Transition.EntranceTween);
				this.exitSequence.Insert(transitionInfo.StartTime, transitionInfo.Transition.ExitTween);
			}

			this.entranceSequence.OnPlay(this.EnterStart);
			this.entranceSequence.OnComplete(this.EnterEnd);
			this.exitSequence.OnPlay(this.ExitStart);
			this.exitSequence.OnComplete(this.ExitEnd);
		}
	}

	public void Deinitialize()
	{
		this.entranceSequence?.Kill();
		this.exitSequence?.Kill();
		foreach (TransitionInfo transitionInfo in this.transitions)
		{
			transitionInfo.Transition.Deinitialize();
		}
	}

	public void Show()
	{
		this.gameObject.SetActive(true);
		if (this.entranceSequence != null)
		{
			this.entranceSequence.Restart();
		}
		else
		{
			this.EnterStart();
			this.EnterEnd();
		}
	}

	public void Hide()
	{
		if (this.exitSequence != null)
		{
			this.exitSequence.Restart();
		}
		else
		{
			this.ExitStart();
			this.ExitEnd();
		}
	}

	protected virtual void OnBackPressed()
	{
	}

	private void ResetTransitions()
	{
		foreach (TransitionInfo transitionInfo in this.transitions)
		{
			transitionInfo.Transition.OnReset();
		}
	}

	public void EnterStart()
	{
		this.ResetTransitions();
		this.DisableAllUIInteractions();

		// Debug.Log($"View {name} Enter Start");
		this.OnEnterStart?.Invoke();
	}

	public void EnterEnd()
	{
		this.EnableAllUIInteractions();

		// Debug.Log($"View {name} Enter End");
		this.isFocused = true;
		this.OnEnterEnd?.Invoke();
	}

	public void ExitStart()
	{
		this.isFocused = false;
		this.DisableAllUIInteractions();

		// Debug.Log($"View {name} Exit Start");
		this.OnExitStart?.Invoke();
	}

	public void ExitEnd()
	{
		// Debug.Log($"View {name} Exit End");
		this.OnExitEnd?.Invoke();

		this.gameObject.SetActive(false);
	}

	#region Selectables
	private void GetSelectables()
	{
		this.selectables = new List<Selectable>();
		foreach (Transform child in this.transform)
		{
			Selectable selectable = child.GetComponent<Selectable>();
			if (selectable != null)
			{
				this.selectables.Add(selectable);
			}

			this.GetSelectablesFromChild(child);
		}
	}

	private void GetSelectablesFromChild(Transform child)
	{
		if (child == null)
		{
			return;
		}

		foreach (Transform obj in child.transform)
		{
			Selectable selectable = obj.GetComponent<Selectable>();
			if (selectable != null)
			{
				this.selectables.Add(selectable);
			}

			this.GetSelectablesFromChild(obj);
		}
	}
	#endregion

	#region UIActions
	protected void SetSelectableActive(Selectable selectable, bool flag)
	{
		if (selectable == null)
		{
			return;
		}

		Selectable findResult = this.selectables.Find(FindPredicate);
		bool FindPredicate(Selectable a) => a.name == selectable.name;
		if (findResult != null)
		{
			findResult.interactable = true;
		}
	}

	protected void EnableAllUIInteractions()
	{
		foreach (Selectable uiSelectable in this.selectables)
		{
			uiSelectable.interactable = true;
		}
	}

	protected void DisableAllUIInteractions()
	{
		foreach (Selectable uiSelectable in this.selectables)
		{
			uiSelectable.interactable = false;
		}
	}
	#endregion
}
