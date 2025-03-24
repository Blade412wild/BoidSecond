using System.Collections.Generic;
using UnityEngine;

public class RuleAllignment : FlockBehaviourBase
{

    public override Vector2 CalculateVelocity(Boid boid, List<Boid> otherBoids)
    {
        Vector2 combinedAllignment = Vector2.zero;

        foreach (Boid otherBoid in otherBoids)
        {
            if (otherBoid == boid) continue;
            if (combinedAllignment == Vector2.zero)
            {
                combinedAllignment = otherBoid.WorldSpacePos;
            }
            else
            {
                combinedAllignment += otherBoid.WorldSpacePos;
            }
        }

        Vector2 percievedMiddlePoint = combinedAllignment / (otherBoids.Count - 1);
        Vector2 direction = percievedMiddlePoint - boid.WorldSpacePos;
        velocity = direction * Scalar;

        combinedAllignment = Vector2.zero;
        if (ShowVelocity == true)
        {
            base.DebugVelocityPos(boid, percievedMiddlePoint);
        }

        return velocity;
    }
}




