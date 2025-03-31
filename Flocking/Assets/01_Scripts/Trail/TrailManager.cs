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
    private float boidsNeededToSwitch;
    private float pointCompletionPercentage;

    private void Start()
    {
        InitializeTrailPoints();
        activeTrailPoint = trailPoints[0];
        boidsNeededToSwitch = activeTrailPoint.boidsNeededToSwitch;
        activeTrailPoint.ChangeColor(Color.green);
    }

    private void Update()
    {
        if (BoidCollided == true)
        {
            BoidCollided = false;
            OnBoidReachingTrailPoint(activeTrailPoint);
        }
    }
    public void OnBoidReachingTrailPoint(TrailPoint trailPoint)
    {
        if (trailPoint != activeTrailPoint) return;
        counter++;
        if (counter >= boidsNeededToSwitch)
        {
            ChangeActivePoint();
            counter = 0;
        }

    }

    private float CalculatePercentage()
    {
        
        float progression = CalculateNewValueInNewScale(counter, 0, pointCompletionPercentage, 0, 100);
        return progression;
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

        activeTrailPoint.DeactivatePoint();

        activeTrailPoint = trailPoints[nextID];
        boidsNeededToSwitch = activeTrailPoint.boidsNeededToSwitch;
        activeTrailPoint.ActivatePoint();

    }

    private void InitializeTrailPoints()
    {
        for (int i = 0; i < trailPoints.Count; i++)
        {
            trailPoints[i].Init(this, i);
        }
    }

    public static float CalculateNewValueInNewScale(float valueOldScale, float oldMin, float oldMax, float newMin, float newMax)
    {
        float newValue = (valueOldScale - oldMin) / (oldMax - oldMin) * (newMax - newMin) + newMin;


        return newValue;
    }

}



