using System.Collections.Generic;
using UnityEngine;

public class RuleSeperation : FlockBehaviourBase
{
    public float MinDistance;
    public override Vector2 CalculateVelocity(Boid boid, List<Boid> otherBoids)
    {
        velocity = Vector2.zero;
        foreach (Boid otherBoid in otherBoids)
        {
            if (otherBoid == boid) continue;
            float distance = Vector2.Distance(boid.WorldSpacePos, otherBoid.WorldSpacePos);
            //Debug.Log(distance);
            if (distance < MinDistance)
            {
                if (boid.Id == 0)
                {
                    Debug.Log(boid.name);
                }

                if (boid.Id == otherBoids.Count - 1)
                {
                    Debug.Log(boid.name);
                }
                velocity += boid.WorldSpacePos - otherBoid.WorldSpacePos;
                if (boid.ShowDebugs == true)
                {
                    base.DebugVelocityPos(boid, otherBoid.WorldSpacePos);
                    Debug.Log("boid : " + boid.transform.name + " -> boid : " + otherBoid.transform.name + " : " + distance);
                    Debug.Log("velocity : " + velocity);
                }
            }
        }

        // bereken het middelepunt van de boids die dichtbij zijn en repel tegen dat punt
        // maar dan gaan ze waarschijnlijk in elkaar

        // ze moeten niet in elkaar gaan

        velocity = velocity * Scalar;

        if (ShowVelocity)
        {
            base.DebugVelocity(boid, velocity);
        }


        return velocity;
    }
}



