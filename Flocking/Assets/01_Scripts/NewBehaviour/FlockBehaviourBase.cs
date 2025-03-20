using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehaviourBase : MonoBehaviour 
{
    public virtual Vector3 CalculateVelocity(Boid boid, List<Boid> otherBoids)
    {
        return Vector3.zero;
    }
}