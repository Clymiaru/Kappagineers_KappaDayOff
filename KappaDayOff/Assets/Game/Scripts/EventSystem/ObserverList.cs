using System;
using System.Collections.Generic;

/*
 * Holds the associated actions associated with the event name
 * Created By: NeilDG
 */
public class ObserverList
{
	private readonly List<Action<Parameters>> eventListeners;         //by default, event listeners with params
	private readonly List<Action>             eventListenersNoParams; //event listeners that does not have params;

	public ObserverList()
	{
		eventListeners         = new List<Action<Parameters>>();
		eventListenersNoParams = new List<Action>();
	}

	public void AddObserver(Action<Parameters> action)
	{
		eventListeners.Add(action);
	}

	public void AddObserver(Action action)
	{
		eventListenersNoParams.Add(action);
	}

	public void RemoveObserver(Action<Parameters> action)
	{
		if (eventListeners.Contains(action))
		{
			eventListeners.Remove(action);
		}
	}

	public void RemoveObserver(Action action)
	{
		if (eventListenersNoParams.Contains(action))
		{
			eventListenersNoParams.Remove(action);
		}
	}

	public void RemoveAllObservers()
	{
		eventListeners.Clear();
		eventListenersNoParams.Clear();
	}

	public void NotifyObservers(Parameters parameters)
	{
		for (int i = 0; i < eventListeners.Count; i++)
		{
			var action = eventListeners[i];

			action(parameters);
		}
	}

	public void NotifyObservers()
	{
		for (int i = 0; i < eventListenersNoParams.Count; i++)
		{
			Action action = eventListenersNoParams[i];

			action();
		}
	}

	public int GetListenerLength()
	{
		return eventListeners.Count + eventListenersNoParams.Count;
	}
}