using System.Collections.Generic;
using UnityEngine;

public class ViewHandler : MonoBehaviour
{
	[SerializeField] private List<View> views;
	[SerializeField] private View       startingView;

	private void Awake()
	{
		foreach (View view in views)
		{
			view.Initialize(this);
		}
	}

	public void Show(View view)
	{
		if (views.Contains(view))
		{
			return;
		}

		views.Add(view);
		view.Initialize(this);
		view.Show();
	}

	private void Start()
	{
		startingView.Show();
	}

	private void OnDestroy()
	{
		foreach (View view in views)
		{
			view.Deinitialize();
		}
	}
}
