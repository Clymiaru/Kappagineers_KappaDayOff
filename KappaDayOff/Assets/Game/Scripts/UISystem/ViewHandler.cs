using System.Collections.Generic;
using UnityEngine;

public class ViewHandler : MonoBehaviour
{
	[SerializeField] private List<View> views;
	[SerializeField] private View       startingView;

	private void Awake()
	{
		foreach (View view in this.views)
		{
			view.Initialize();
		}
	}

	private void Start()
	{
		this.startingView.Show();
	}

	private void OnDestroy()
	{
		foreach (View view in this.views)
		{
			view.Deinitialize();
		}
	}
}