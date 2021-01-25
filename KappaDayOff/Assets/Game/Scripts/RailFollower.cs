using UnityEngine;

public class RailFollower : MonoBehaviour
{
	public  LineRenderer rail;
	public  float[]      durationGoingToEachPoint;
	private int          currentRailpointIndex = 1;
	private float        currentTravelTime;
	private Vector3[]    railPoints;

	private void Awake()
	{
		railPoints = new Vector3[rail.positionCount];
		rail.GetPositions(railPoints);
		gameObject.transform.position = railPoints[0];
	}

	// Update is called once per frame
	private void Update()
	{
		if (currentRailpointIndex < railPoints.Length)
		{
			gameObject.transform.position = Vector3.Lerp(railPoints[currentRailpointIndex - 1],
			                                             railPoints[currentRailpointIndex], currentTravelTime / durationGoingToEachPoint[currentRailpointIndex - 1]);
			currentTravelTime = Mathf.Clamp(currentTravelTime + Time.deltaTime, 0, durationGoingToEachPoint[currentRailpointIndex - 1]);
			if (currentTravelTime == durationGoingToEachPoint[currentRailpointIndex - 1])
			{
				currentRailpointIndex++;
				currentTravelTime = 0;
			}
		}
		else
		{
			Debug.Log("End!");
			SceneLoader.Instance.LoadScene(SceneNames.MainMenu);
		}
	}
}