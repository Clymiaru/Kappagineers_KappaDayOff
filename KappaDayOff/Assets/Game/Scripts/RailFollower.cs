using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailFollower : MonoBehaviour
{
    public LineRenderer rail;
    public float[] durationGoingToEachPoint;
    private Vector3[] railPoints;
    private int currentRailpointIndex = 1;
    private float currentTravelTime = 0;

    public AdsManager adsManager;

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
            this.gameObject.transform.position = Vector3.Lerp(railPoints[currentRailpointIndex - 1],
                railPoints[currentRailpointIndex], currentTravelTime / durationGoingToEachPoint[currentRailpointIndex - 1]);
            currentTravelTime = Mathf.Clamp(currentTravelTime + Time.deltaTime, 0, durationGoingToEachPoint[currentRailpointIndex - 1]);
            if (currentTravelTime == durationGoingToEachPoint[currentRailpointIndex - 1])
            {
                currentRailpointIndex++;
                currentTravelTime = 0;
            }
        }
        else if (this.gameObject.GetComponent<PlayerStats>() != null)
        {
            if (adsManager != null)
                adsManager.ShowInterstitialAd();
            Debug.Log("End!");
            SceneLoader.Instance.LoadScene(SceneNames.MainMenu);
        }
        
        
    }
}
