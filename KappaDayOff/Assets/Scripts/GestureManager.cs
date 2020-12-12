using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GestureManager : MonoBehaviour
{
    public event EventHandler<SwipeEventArgs> OnSwipe;

    public static GestureManager Instance;

    public SwipeProperty _swipeProperty;

    private Vector2 startPoint = Vector2.zero;
    private Vector2 endPoint = Vector2.zero;
    private float gestureTime = 0;

    public CucumberMissile bomb;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    Touch trackedFinger1;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            trackedFinger1 = Input.GetTouch(0);

            if (trackedFinger1.phase == TouchPhase.Began)
            {
                startPoint = trackedFinger1.position;
                gestureTime = 0;
            }
            else if (trackedFinger1.phase == TouchPhase.Ended)
            {
                endPoint = trackedFinger1.position;

                if (gestureTime <= _swipeProperty.swipeTime && 
                    (Vector2.Distance(startPoint, endPoint) >= (_swipeProperty.minSwipeDistance * Screen.dpi)))
                {
                    FireSwipeEvent();
                }
            }
            else
            {
                gestureTime += Time.deltaTime;
            }
        }
    }

    private void FireSwipeEvent()
    {
        Vector2 diff = endPoint - startPoint;

        SwipeDirections swipeDir = SwipeDirections.RIGHT;

        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            if (diff.x > 0)
            {
                Debug.Log("Right");
                swipeDir = SwipeDirections.RIGHT;
            }
            else
            {
                Debug.Log("Left");
                swipeDir = SwipeDirections.LEFT;
            }
        }
        else
        {
            if (diff.y > 0)
            {
                Debug.Log("Up");
                swipeDir = SwipeDirections.UP;
            }
            else
            {
                Debug.Log("Down");
                swipeDir = SwipeDirections.DOWN;
            }
        }

        if (OnSwipe != null)
        {
            OnSwipe(this, new SwipeEventArgs(startPoint, diff, swipeDir));
        }

        if (bomb != null)
        {
            bomb.OnSwipe(new SwipeEventArgs(startPoint, diff, swipeDir));
        }
    }
}
