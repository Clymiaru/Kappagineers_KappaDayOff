using System;
using UnityEngine;

public class JoystickAim : MonoBehaviour
{
    [SerializeField] private Joystick   joystick  = null;
    [SerializeField] private GameObject crosshair = null;

    [SerializeField] SpriteRenderer spriteRenderer = null;
    
    private void Update()
    {
        spriteRenderer.flipX = joystick.JoystickVector.x > 0.0f;
        
        float angle = Mathf.Atan2(joystick.JoystickVector.y, joystick.JoystickVector.x) * Mathf.Rad2Deg;
        crosshair.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0.0f, 0.0f ,1.0f));

    }
}
