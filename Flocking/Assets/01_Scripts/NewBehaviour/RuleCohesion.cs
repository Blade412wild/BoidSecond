﻿using System.Collections.Generic;
using UnityEngine;

public class RuleCohesion : FlockBehaviourBase
{
    private Vector2 middlePoint;
    public override Vector2 CalculateVelocity(Boid boid, List<Boid> otherBoids)
    {
        middlePoint = Vector2.zero;

        foreach (Boid otherBoid in otherBoids)
        {
            if(otherBoid == boid) continue;
            if(middlePoint == Vector2.zero)
            {
                middlePoint = otherBoid.WorldSpacePos;
            }
            else
            {
                middlePoint += otherBoid.WorldSpacePos;
            }
        }

        Vector2 percievedMiddlePoint = middlePoint / (otherBoids.Count - 1);
        Vector2 direction = percievedMiddlePoint - boid.WorldSpacePos;
        velocity = direction * Scalar;

        middlePoint = Vector2.zero;
        if(ShowVelocity == true)
        {
            ShowMiddlePoint(boid, percievedMiddlePoint);
        }

        return velocity;
    }

    private void ShowMiddlePoint(Boid boid, Vector2 middlePoint)
    {
        Debug.DrawRay(boid.transform.position, (middlePoint - boid.WorldSpacePos).normalized, DebugColor);
    }
}




