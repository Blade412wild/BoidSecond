using System.Collections.Generic;
using UnityEngine;

public class RuleMoveForward : FlockBehaviourBase
{
    
    public override Vector2 CalculateVelocity(Boid boid, List<Boid> otherBoids, FlockManager flockManager)
    {
        boid.Speed = Scalar;
        Vector2 direction = boid.transform.right.normalized;
        Vector2 velocity = direction * boid.Speed;
        //TargetPos = Camera.main.ScreenToWorldPoint(screenPos);
        //transform.position = TargetPos;
        return velocity;
    }
}



