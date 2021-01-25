// Originally Made By: _Adriaan
// Lifted from: https://forum.unity.com/threads/canvashelper-resizes-a-recttransform-to-iphone-xs-safe-area.521107/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class CanvasHelper : MonoBehaviour
{
	private static readonly List<CanvasHelper> helpers = new List<CanvasHelper>();

	public static UnityEvent OnResolutionOrOrientationChanged = new UnityEvent();

	private static bool              screenChangeVarsInitialized;
	private static ScreenOrientation lastOrientation = ScreenOrientation.Landscape;
	private static Vector2           lastResolution  = Vector2.zero;
	private static Rect              lastSafeArea    = Rect.zero;

	private Canvas        canvas;
	private RectTransform rectTransform;
	private RectTransform safeAreaTransform;

	private void Awake()
	{
		if (!helpers.Contains(this))
		{
			helpers.Add(this);
		}

		canvas        = GetComponent<Canvas>();
		rectTransform = GetComponent<RectTransform>();

		safeAreaTransform = transform.Find("SafeArea") as RectTransform;

		if (!screenChangeVarsInitialized)
		{
			lastOrientation  = Screen.orientation;
			lastResolution.x = Screen.width;
			lastResolution.y = Screen.height;
			lastSafeArea     = Screen.safeArea;

			screenChangeVarsInitialized = true;
		}

		ApplySafeArea();
	}

	private void Update()
	{
		if (helpers[0] != this)
		{
			return;
		}

		if (Application.isMobilePlatform &&
		    Screen.orientation != lastOrientation)
		{
			OrientationChanged();
		}

		if (Screen.safeArea != lastSafeArea)
		{
			SafeAreaChanged();
		}

		if (Math.Abs(Screen.width  - lastResolution.x) > float.Epsilon ||
		    Math.Abs(Screen.height - lastResolution.y) > float.Epsilon)
		{
			ResolutionChanged();
		}
	}

	private void OnDestroy()
	{
		if (helpers != null &&
		    helpers.Contains(this))
		{
			helpers.Remove(this);
		}
	}

	private void ApplySafeArea()
	{
		if (safeAreaTransform == null)
		{
			return;
		}

		Rect safeArea = Screen.safeArea;

		Vector2 anchorMin = safeArea.position;
		Vector2 anchorMax = safeArea.position + safeArea.size;

		Rect pixelRect = canvas.pixelRect;

		anchorMin.x /= pixelRect.width;
		anchorMin.y /= pixelRect.height;
		anchorMax.x /= pixelRect.width;
		anchorMax.y /= pixelRect.height;

		safeAreaTransform.anchorMin = anchorMin;
		safeAreaTransform.anchorMax = anchorMax;
	}

	private static void OrientationChanged()
	{
		lastOrientation  = Screen.orientation;
		lastResolution.x = Screen.width;
		lastResolution.y = Screen.height;

		OnResolutionOrOrientationChanged.Invoke();
	}

	private static void ResolutionChanged()
	{
		lastResolution.x = Screen.width;
		lastResolution.y = Screen.height;

		OnResolutionOrOrientationChanged.Invoke();
	}

	private static void SafeAreaChanged()
	{
		lastSafeArea = Screen.safeArea;

		foreach (CanvasHelper helper in helpers)
		{
			helper.ApplySafeArea();
		}
	}
}
