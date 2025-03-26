using System.Collections.Generic;
using UnityEngine;

public class RuleSeperation : FlockBehaviourBase
{
    public float MinDistance;
    public override Vector2 CalculateVelocity(Boid boid, List<Boid> otherBoids, FlockManager flockManager)
    {
        velocity = Vector2.zero;
        foreach (Boid otherBoid in otherBoids)
        {
            if (otherBoid == boid) continue;
            float distance = Vector2.Distance(boid.WorldSpacePos, otherBoid.WorldSpacePos);
            //Debug.Log(distance);
            if (distance < MinDistance)
            {
                velocity += boid.WorldSpacePos - otherBoid.WorldSpacePos;
                if (boid.ShowDebugs == true)
                {
                    base.DebugVelocityPos(boid, otherBoid.WorldSpacePos);
                }
            }
        }

        velocity = velocity * Scalar;

        if (ShowVelocity)
        {
            base.DebugVelocity(boid, velocity);
        }


        return velocity;
    }
}



