using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct TransitionInfo
{
	public float      StartTime;
	public ViewAnimation viewAnimation;
}

[RequireComponent(typeof(CanvasHelper))]
public class View : MonoBehaviour
{
	[Header("Transitions"), SerializeField]
	private List<TransitionInfo> transitions = new List<TransitionInfo>();

	private Sequence entranceSequence;
	private Sequence exitSequence;

	protected bool   isFocused;
	protected Action OnEnterEnd;

	protected Action OnEnterStart;
	protected Action OnExitEnd;
	protected Action OnExitStart;

	protected ViewHandler viewHandler;

	private List<Selectable> selectables = new List<Selectable>();

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) &&
		    isFocused)
		{
			OnBackPressed();
		}
	}

	public void Initialize(ViewHandler handler)
	{
		viewHandler = handler;
		GetSelectables();
		if (transitions.Count > 0)
		{
			entranceSequence = DOTween.Sequence().SetAutoKill(false);
			exitSequence     = DOTween.Sequence().SetAutoKill(false);
			foreach (TransitionInfo transitionInfo in transitions)
			{
				transitionInfo.viewAnimation.Intialize();
				entranceSequence.Insert(transitionInfo.StartTime, transitionInfo.viewAnimation.EntranceTween);
				exitSequence.Insert(transitionInfo.StartTime, transitionInfo.viewAnimation.ExitTween);
			}

			entranceSequence.OnPlay(EnterStart);
			entranceSequence.OnComplete(EnterEnd);
			exitSequence.OnPlay(ExitStart);
			exitSequence.OnComplete(ExitEnd);
		}

		OnInitialize();
	}

	public void Deinitialize()
	{
		entranceSequence?.Kill();
		exitSequence?.Kill();
		foreach (TransitionInfo transitionInfo in transitions)
		{
			transitionInfo.viewAnimation.Deinitialize();
		}
	}

	public void Show()
	{
		gameObject.SetActive(true);
		if (entranceSequence != null)
		{
			entranceSequence.Restart();
		}
		else
		{
			EnterStart();
			EnterEnd();
		}
	}

	public void Hide()
	{
		if (exitSequence != null)
		{
			exitSequence.Restart();
		}
		else
		{
			ExitStart();
			ExitEnd();
		}
	}

	protected virtual void OnInitialize()
	{
	}

	protected virtual void OnBackPressed()
	{
	}

	private void ResetTransitions()
	{
		foreach (TransitionInfo transitionInfo in transitions)
		{
			transitionInfo.viewAnimation.OnReset();
		}
	}

	public void EnterStart()
	{
		ResetTransitions();
		DisableAllUIInteractions();

		// Debug.Log($"View {name} Enter Start");
		OnEnterStart?.Invoke();
	}

	public void EnterEnd()
	{
		EnableAllUIInteractions();

		// Debug.Log($"View {name} Enter End");
		isFocused = true;
		OnEnterEnd?.Invoke();
	}

	public void ExitStart()
	{
		isFocused = false;
		DisableAllUIInteractions();

		// Debug.Log($"View {name} Exit Start");
		OnExitStart?.Invoke();
	}

	public void ExitEnd()
	{
		// Debug.Log($"View {name} Exit End");
		OnExitEnd?.Invoke();
		gameObject.SetActive(false);
	}

	#region Selectables
	private void GetSelectables()
	{
		selectables = new List<Selectable>();
		foreach (Transform child in transform)
		{
			var selectable = child.GetComponent<Selectable>();
			if (selectable != null)
			{
				selectables.Add(selectable);
			}

			GetSelectablesFromChild(child);
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
			var selectable = obj.GetComponent<Selectable>();
			if (selectable != null)
			{
				selectables.Add(selectable);
			}

			GetSelectablesFromChild(obj);
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

		Selectable findResult = selectables.Find(FindPredicate);

		bool FindPredicate(Selectable a)
		{
			return a.name == selectable.name;
		}

		if (findResult != null)
		{
			findResult.interactable = true;
		}
	}

	protected void EnableAllUIInteractions()
	{
		foreach (Selectable uiSelectable in selectables)
		{
			uiSelectable.interactable = true;
		}
	}

	protected void DisableAllUIInteractions()
	{
		foreach (Selectable uiSelectable in selectables)
		{
			uiSelectable.interactable = false;
		}
	}
	#endregion
}
