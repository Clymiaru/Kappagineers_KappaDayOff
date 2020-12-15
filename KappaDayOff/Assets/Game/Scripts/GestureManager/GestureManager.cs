using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GestureManager : MonoBehaviour
{
    public static GestureManager Instance = null;
    
    #region Gesture Event Handlers

    public event Action OnBack;
    public event EventHandler<TapEventArgs>   OnTap;
    public event EventHandler<SwipeEventArgs> OnSwipe;
    public event EventHandler<PanEventArgs> onTwoFingerDrag;
    public event EventHandler<PinchEventArgs> onPinchSpread;

    #endregion
    
    #region Gesture Properties

    public TapProperty   _tapProperty;
    public SwipeProperty _swipeProperty;
    public PanProperty _panProperty;
    public PinchProperty _pinchProperty;
    public DoubleTapProperty _doubleTapProperty;
    
    #endregion
    
    private Vector2 startPoint = Vector2.zero;
    private Vector2 endPoint = Vector2.zero;
    private float gestureTime = 0;
    private float lastTapTime = 0;

    public CucumberMissile bomb;
    public BarrierBehavior barrier;
    
    private readonly List<Touch> touches = new List<Touch>();
    private Camera mainCamera = null;
    
    Touch trackedFinger1;
    Touch trackedFinger2;

    private void Awake()
    {
        mainCamera = Camera.main;
        
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OnBack?.Invoke();
        }
        
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1)
            {
                trackedFinger1 = Input.GetTouch(0);

                if (trackedFinger1.phase == TouchPhase.Began)
                {
                    startPoint = trackedFinger1.position;
                    gestureTime = 0.0f;
                }
                else if (trackedFinger1.phase == TouchPhase.Ended)
                {
                    if (lastTapTime <= _doubleTapProperty.MaxTapTimeDistance)
                    {
                        FireDoubleTapEvent();
                    }
                    else
                    {
                        endPoint = trackedFinger1.position;

                        float currentTapDistance = Vector2.Distance(startPoint, endPoint);
                        float approvedTapDistance = _tapProperty.TapMaxDistance * Screen.dpi;

                        if (gestureTime <= _tapProperty.TapTime &&
                            currentTapDistance < approvedTapDistance)
                        {
                            FireTapEvent();
                        }


                        if (gestureTime <= _swipeProperty.swipeTime &&
                            (Vector2.Distance(startPoint, endPoint) >= (_swipeProperty.minSwipeDistance * Screen.dpi)))
                        {
                            FireSwipeEvent();
                        }
                    }

                    lastTapTime = 0;
                }
                else
                {
                    gestureTime += Time.deltaTime;
                }
            }
            else
            {
                trackedFinger1 = Input.GetTouch(0);
                trackedFinger2 = Input.GetTouch(1);

                if (trackedFinger1.phase == TouchPhase.Moved && trackedFinger2.phase == TouchPhase.Moved &&
                    Vector2.Distance(trackedFinger1.position, trackedFinger2.position) <= (_panProperty.MaxDistance * Screen.dpi))
                {
                    FirePanGesture();
                }
                else if (trackedFinger1.phase == TouchPhase.Moved || trackedFinger2.phase == TouchPhase.Moved)
                {
                    Vector2 prevPoint1 = GetPreviousPoint(trackedFinger1);
                    Vector2 prevPoint2 = GetPreviousPoint(trackedFinger2);

                    float currDistance = Vector2.Distance(trackedFinger1.position, trackedFinger2.position);
                    float prevDistance = Vector2.Distance(prevPoint1, prevPoint2);

                    if (Mathf.Abs(currDistance - prevDistance) >= (_pinchProperty.MinDistanceChange * Screen.dpi))
                    {
                        FirePinchEvent(currDistance - prevDistance);
                    }
                }
            }
        }
        lastTapTime += Time.deltaTime;
    }

    private void FireTapEvent() 
    {
        var hitObj = GetHitInfo(startPoint);

        var args = new TapEventArgs(startPoint, hitObj);

        OnTap?.Invoke (this, args);

        if (hitObj is null) 
        {
            return;
        }

        var tap = hitObj.GetComponent<ITapped>();
        tap.OnTap (args);
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
    
    private GameObject GetHitInfo (Vector2 screenPos) 
    {
        var ray = mainCamera.ScreenPointToRay (screenPos);
        bool hasHit = Physics.Raycast (ray, out var hitInfo, Mathf.Infinity);
        return (hasHit is true) ? hitInfo.collider.gameObject : null;
    }

    private void FirePanGesture()
    {
        PanEventArgs args = new PanEventArgs(trackedFinger1, trackedFinger2);
        if (onTwoFingerDrag != null)
        {
            onTwoFingerDrag(this, args);
        }
    }

    private Vector2 GetPreviousPoint(Touch t)
    {
        return t.position - t.deltaPosition;
    }

    private void FirePinchEvent(float dist_diff)
    {
        PinchEventArgs args = new PinchEventArgs(trackedFinger1, trackedFinger2, dist_diff);
        if (onPinchSpread != null)
        {
            onPinchSpread(this, args);
        }
    }

    private void FireDoubleTapEvent()
    {
        barrier.ActivateBarrier();
    }
    
    // private void OnDrawGizmos()
    // {
    //     if (Input.touchCount <= 0)
    //     {
    //         return;
    //     }
    //
    //     foreach (var touch in touches)
    //     {
    //         var ray = mainCamera.ScreenPointToRay(touch.position);
    //         
    //         Gizmos.color = Color.red;
    //         Gizmos.DrawSphere(ray.GetPoint(5.0f), 0.5f);
    //     }
    // }
}
