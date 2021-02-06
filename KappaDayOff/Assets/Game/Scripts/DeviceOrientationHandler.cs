using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOrientationHandler : MonoBehaviour
{
    public static DeviceOrientationHandler Instance { get; private set; }

    public event System.Action<DeviceOrientation> OnOrientationUpdate;

    private DeviceOrientation previousOrientation;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        DeviceOrientation currentOrientation = Input.deviceOrientation;

        if (currentOrientation != previousOrientation)
        {
            Debug.Log("Testing orientation");
            OnOrientationUpdate?.Invoke(currentOrientation);
            previousOrientation = currentOrientation;
        }
    }
}
