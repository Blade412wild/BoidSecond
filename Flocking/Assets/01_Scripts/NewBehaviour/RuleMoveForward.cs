using System.Collections.Generic;
using UnityEngine;

public class RuleMoveForward : FlockBehaviourBase
{
    public override Vector3 CalculateVelocity(Boid boid, List<Boid> otherBoids)
    {
        Vector2 direction = boid.transform.up.normalized;
        Vector2 velocity = direction * boid.Speed;
        //TargetPos = Camera.main.ScreenToWorldPoint(screenPos);
        //transform.position = TargetPos;
        return velocity;
    }
}



