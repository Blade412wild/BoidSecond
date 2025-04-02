using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RuleAllignment : FlockBehaviourBase
{
    [SerializeField] bool useSmoothRotation;
    [SerializeField] bool useNormalRotation;

    [SerializeField] private int updateRotationAfterIteration = 0;
    [SerializeField] private float angleThreshold;

    [SerializeField] private float minRotationSpeed = 1f;  // Speed when angle is small
    [SerializeField] private float maxRotationSpeed = 10f; // Speed when angle is large
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
        HandleRotation(boid);

        //smoothRotation3(boid);
        //if (boid.RotationIterationCounter >= updateRotationAfterIteration)
        //{
        //    //SmoothRotation(boid, velocity);
        //    if (useNormalRotation)
        //    {
        //        NormalRotation(boid);
        //    }
        //    else if (useSmoothRotation)
        //    {
        //        smoothRotation3(boid, velocity);
        //    }

        //    boid.RotationIterationCounter = 0;
        //}



        boid.RotationIterationCounter++;
        return velocity;
    }

    private void HandleRotation(Boid boid)
    {
        Vector2 futurePos = boid.transform.position + boid.Velocity;
        Vector2 direction = boid.WorldSpacePos - futurePos;

        float targetAngle = Mathf.Atan2(boid.Velocity.y, boid.Velocity.x) * Mathf.Rad2Deg;
        float targetAngle2 = Vector2.SignedAngle(Vector2.up, direction);
        float currentAngle = boid.transform.eulerAngles.z;

        float angleDifference = Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetAngle));
        float dynamicSpeed = Mathf.Lerp(minRotationSpeed, maxRotationSpeed, angleDifference / 180f);

        if (boid.RotationIterationCounter > updateRotationAfterIteration)
        {
            if (boid.Id == 0)
            {
                float shortestAngle = Mathf.DeltaAngle(boid.transform.rotation.z, targetAngle);

                Debug.Log("euler.z : " + angleDifference + " | targetangle.z : " + targetAngle + "| targetAngle2 : " + targetAngle2);
            }
            if (useNormalRotation)
            {
                NormalRotation(boid, targetAngle2);
            }
            else
            {
                smoothRotation(boid, currentAngle, targetAngle, dynamicSpeed);
            }

            boid.RotationIterationCounter = 0;
        }
    }

    void smoothRotation(Boid boid, float currentAngle, float targetAngle, float dynamicSpeed)
    {
        float newAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref boid.angleRef, 1f / dynamicSpeed);
        boid.transform.rotation = Quaternion.Euler(0, 0, newAngle);

    }

    private void NormalRotation2(Boid boid)
    {
        float targetAngle = Mathf.Atan2(boid.Velocity.y, boid.Velocity.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle - 90f);

        float shortestAngle = Mathf.DeltaAngle(boid.transform.rotation.z, targetAngle);

        if (shortestAngle > (angleThreshold * -1) && shortestAngle < angleThreshold)
        {
            Debug.Log("to small angle");
        }
        else
        {
            Debug.Log("bigger angle");
            boid.transform.rotation = targetRotation;
        }

    }

    void smoothRotation3(Boid boid)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - boid.transform.position;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngle = boid.transform.eulerAngles.z;

        // Calculate shortest angle difference
        float angleDifference = Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetAngle));

        // Dynamic rotation speed (scale between min and max)
        float dynamicSpeed = Mathf.Lerp(minRotationSpeed, maxRotationSpeed, angleDifference / 180f);

        // Rotate only if the difference is significant
        if (angleDifference > 1f)
        {
            float newAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref boid.angleRef, 1f / dynamicSpeed);
            boid.transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
    }
    private void NormalRotation(Boid boid, float targetAngle)
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle );
        boid.transform.rotation = targetRotation;
    }


}





