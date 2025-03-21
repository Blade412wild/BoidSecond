using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehaviourBase : MonoBehaviour 
{
    [Header("Settings")]
    [field: SerializeField] public float Scalar { get; protected set; }
    [field: SerializeField] public bool ShowVelocity { get; protected set; }
    [field: SerializeField] public Color DebugColor { get; protected set; }

    protected Vector2 velocity;


    public virtual Vector2 CalculateVelocity(Boid boid, List<Boid> otherBoid)
    {
        return Vector2.zero;
    }
}