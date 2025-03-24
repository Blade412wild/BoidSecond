using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehaviourBase : MonoBehaviour
{
    [Header("Settings")]
    [field: SerializeField] public float Scalar { get; protected set; }
    [field: SerializeField] public bool ShowVelocity { get; protected set; }
    [field: SerializeField] public Color DebugColor { get; protected set; }

    protected Vector2 velocity;


    public virtual Vector2 CalculateVelocity(Boid boid, List<Boid> otherBoid, FlockManager flockManager)
    {
        return Vector2.zero;
    }

    public virtual void DebugVelocityPos(Boid boid, Vector2 targetPos)
    {
        if (boid.ShowDebugs != true) return;
        Debug.DrawRay(boid.transform.position, (targetPos - boid.WorldSpacePos).normalized, DebugColor);
    }
    public virtual void DebugVelocity(Boid boid, Vector2 targetVelocity)
    {
        if (boid.ShowDebugs != true) return;
        Debug.DrawRay(boid.transform.position, targetVelocity, DebugColor);
    }


}