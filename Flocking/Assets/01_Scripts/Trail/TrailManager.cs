using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class TrailManager : MonoBehaviour
{
    [SerializeField] private FlockManager flockManager;
    [SerializeField] private List<TrailPoint> trailPoints;

    [SerializeField] private bool BoidCollided;
    [SerializeField] private int counter;

    public TrailPoint activeTrailPoint { get; private set; }
    private float activePercentage;
    private float pointCompletionPercentage;

    private void Start()
    {
        InitializeTrailPoints();
        activeTrailPoint = trailPoints[0];
        activePercentage = activeTrailPoint.completionPercentage;
        activeTrailPoint.ChangeColor(Color.green);
    }

    private void Update()
    {
        if (BoidCollided == true)
        {
            BoidCollided = false;
            OnBoidReachingTrailPoint();
        }
    }
    public void OnBoidReachingTrailPoint()
    {
        counter++;
        pointCompletionPercentage = CalculatePercentage();
        if (pointCompletionPercentage >= activePercentage)
        {
            ChangeActivePoint();
            counter = 0;
        }

    }

    private float CalculatePercentage()
    {
        //activePercentage
        return 100.0f;
    }

    private void ChangeActivePoint()
    {
        int nextID;
        if (activeTrailPoint.Id == trailPoints.Count - 1)
        {
            nextID = 0;
        }
        else
        {
            nextID = activeTrailPoint.Id + 1;
        }

        activeTrailPoint.ChangeColor(Color.white);

        activeTrailPoint = trailPoints[nextID];
        activePercentage = activeTrailPoint.completionPercentage;
        activeTrailPoint.ChangeColor(Color.green);

    }

    private void InitializeTrailPoints()
    {
        for (int i = 0; i < trailPoints.Count; i++)
        {
            trailPoints[i].Init(this, i);
        }
    }

}



