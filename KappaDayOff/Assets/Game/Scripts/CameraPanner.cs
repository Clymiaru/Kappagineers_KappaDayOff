using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanner : MonoBehaviour
{
    public float speed = 10;
    public float scaleSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        GestureManager.Instance.onTwoFingerDrag += OnTwoFingerDrag;
        GestureManager.Instance.onPinchSpread += OnPinchSpread;
    }

    private void OnDisable()
    {
        GestureManager.Instance.onTwoFingerDrag -= OnTwoFingerDrag;
        GestureManager.Instance.onPinchSpread -= OnPinchSpread;
    }

    private void OnTwoFingerDrag(object sender, PanEventArgs e)
    {
        Vector2 delta1 = e.finger1.deltaPosition;
        Vector2 delta2 = e.finger2.deltaPosition;

        Vector2 ave = new Vector2((delta1.x + delta2.x) / 2, (delta1.y + delta2.y) / 2);

        ave /= Screen.dpi;

        Vector3 change = (Vector3)ave * speed;

        transform.position += change;
    }

    private void OnPinchSpread(object sender, PinchEventArgs e)
    {
        float scale = e.DistanceDiff / Screen.dpi * scaleSpeed;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + scale, 5, 8.4f);
    }
}
