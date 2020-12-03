using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    protected Vector3 destination;
    protected Vector3 flightDirection;
    protected float speed = 0.25f;
    protected int damage = 10;

    public void SetBulletDestination(Vector3 target)
    {
        destination = target;
        flightDirection = (target - gameObject.transform.position).normalized;
    }

    private void Update()
    {
        gameObject.transform.position += speed * flightDirection;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
