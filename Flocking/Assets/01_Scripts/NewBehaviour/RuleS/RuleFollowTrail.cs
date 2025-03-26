using System.Collections.Generic;
using UnityEngine;
public class RuleFollowTrail : FlockBehaviourBase
{
    public override Vector2 CalculateVelocity(Boid boid, List<Boid> otherBoids, FlockManager flockManager)
    {
        velocity = Vector2.zero;
        Vector2 dir = Converter.ToVector2(flockManager.trailManager.activeTrailPoint.transform.position) - boid.WorldSpacePos;

        velocity = dir.normalized * Scalar;

        return velocity;
    }
}



