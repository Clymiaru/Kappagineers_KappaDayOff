using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailFollower : MonoBehaviour
{
    public float speed = 30f;
    public LineRenderer rail;
    private Vector3[] railPoints;
    private int currentRailpointIndex = 1;

    private void Awake()
    {
        railPoints = new Vector3[rail.positionCount];
        rail.GetPositions(railPoints);
        this.gameObject.transform.position = railPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRailpointIndex < railPoints.Length)
        {
            Vector3 movementDirection = (railPoints[currentRailpointIndex] - railPoints[currentRailpointIndex - 1]).normalized;

            this.gameObject.transform.position += movementDirection * this.speed * Time.deltaTime;

            if (movementDirection.x > 0 && this.gameObject.transform.position.x > railPoints[currentRailpointIndex].x ||
                movementDirection.x < 0 && this.gameObject.transform.position.x < railPoints[currentRailpointIndex].x)
            {
                this.gameObject.transform.position = railPoints[currentRailpointIndex];
                currentRailpointIndex++;
            }
            else if (movementDirection.x == 0)
            {
                if (movementDirection.y > 0 && this.gameObject.transform.position.y > railPoints[currentRailpointIndex].y ||
                    movementDirection.y < 0 && this.gameObject.transform.position.y < railPoints[currentRailpointIndex].y)
                {
                    this.gameObject.transform.position = railPoints[currentRailpointIndex];
                    currentRailpointIndex++;
                }
                else if (movementDirection.y == 0)
                {
                    if (movementDirection.z > 0 && this.gameObject.transform.position.z > railPoints[currentRailpointIndex].z ||
                        movementDirection.z < 0 && this.gameObject.transform.position.z < railPoints[currentRailpointIndex].z)
                    {
                        this.gameObject.transform.position = railPoints[currentRailpointIndex];
                        currentRailpointIndex++;
                    }
                }
            }
        }
    }
}
