using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RuleAllignment : FlockBehaviourBase
{
    [SerializeField] bool useSmoothRotation;
    [SerializeField] bool useNormalRotation;

    [SerializeField] private float rotationSpeed = 0.1f;
    [SerializeField] private int updateRotationAfterIteration = 0;
    private int iterationCounter = 0;
    public override Vector2 CalculateVelocity(Boid boid, List<Boid> otherBoids, FlockManager flockManager)
    {
        velocity = Vector2.zero;
        Vector3 perceivedVelocity = Vector3.zero;

        foreach (Boid otherBoid in otherBoids)
        {
            if (otherBoid == boid) continue;

            perceivedVelocity += otherBoid.Velocity;

        }

        Vector2 percieved = perceivedVelocity / (otherBoids.Count - 1);
        velocity = percieved * Scalar;
        if (boid.RotationIterationCounter >= updateRotationAfterIteration)
        {
            //SmoothRotation(boid, velocity);
            if (useNormalRotation)
            {
                NormalRotation(boid);
            }
            else if (useSmoothRotation)
            {
                SmoothRotation(boid, velocity);
            }

            boid.RotationIterationCounter = 0;
        }



        //NormalRotation(boid);
        boid.RotationIterationCounter++;
        return velocity;
    }

    private void SmoothRotation(Boid boid, Vector2 velocity)
    {
        float targetAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle - 90f);

        float angle = Mathf.SmoothDampAngle(boid.transform.eulerAngles.z, targetAngle, ref boid.angleRef, rotationSpeed);

        boid.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        //boid.transform.rotation = targetRotation;
    }

    private void NormalRotationArt(Boid boid)
    {
        float targetAngle = Mathf.Atan2(boid.Velocity.y, boid.Velocity.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle - 90f);
        boid.Art.rotation = targetRotation;
    }

    private void NormalRotation(Boid boid)
    {
        float targetAngle = Mathf.Atan2(boid.Velocity.y, boid.Velocity.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle - 90f);
        boid.transform.rotation = targetRotation;
    }


}





