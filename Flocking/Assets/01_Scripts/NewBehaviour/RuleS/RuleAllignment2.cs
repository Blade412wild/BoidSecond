using System.Collections.Generic;
using UnityEngine;

public class RuleAllignment2 : FlockBehaviourBase
{
    [SerializeField] bool useSmoothRotation;
    [SerializeField] bool useNormalRotation;

    [SerializeField] private int updateRotationAfterIteration = 0;
    [SerializeField] private float angleThreshold;

    [SerializeField] private float minRotationSpeed = 1f;  // Speed when angle is small
    [SerializeField] private float maxRotationSpeed = 10f; // Speed when angle is large

    [Space]
    [SerializeField] private float smoothTime;
    [SerializeField] private float maxTurnSpeed = 90;
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

        boid.RotationIterationCounter++;
        return velocity;
    }

    private void HandleRotation(Boid boid)
    {
        //followMouse(boid);
        //AdaptiveRotationSpeedFollowMouse(boid);
        AdaptiveRotationToVelocity(boid);
        //Vector2 futurePos = boid.transform.position + boid.Velocity;
        //Vector2 direction = boid.WorldSpacePos - futurePos;

        //float targetAngle = Mathf.Atan2(boid.Velocity.y, boid.Velocity.x) * Mathf.Rad2Deg;
        //float targetAngle2 = Vector2.SignedAngle(Vector2.up, direction);
        //float currentAngle = boid.transform.eulerAngles.z;

        //float angleDifference = Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetAngle));
        //float dynamicSpeed = Mathf.Lerp(minRotationSpeed, maxRotationSpeed, angleDifference / 180f);

        //if (boid.RotationIterationCounter > updateRotationAfterIteration)
        //{
        //    if (boid.Id == 0)
        //    {
        //        float shortestAngle = Mathf.DeltaAngle(boid.transform.rotation.z, targetAngle);

        //        Debug.Log("euler.z : " + angleDifference + " | targetangle.z : " + targetAngle + "| targetAngle2 : " + targetAngle2);
        //    }
        //    if (useNormalRotation)
        //    {
        //        NormalRotation(boid, targetAngle2);
        //    }
        //    else
        //    {
        //        smoothRotation(boid, currentAngle, targetAngle, dynamicSpeed);
        //    }

        //    boid.RotationIterationCounter = 0;
        //}
    }

    void smoothRotation(Boid boid, float currentAngle, float targetAngle, float dynamicSpeed)
    {
        float newAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref boid.angleRef, 1f / dynamicSpeed);
        boid.transform.rotation = Quaternion.Euler(0, 0, newAngle);

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
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        boid.transform.rotation = targetRotation;
    }

    void followMouse(Boid boid)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - boid.transform.position;
        float targetAngle = Vector2.SignedAngle(Vector2.right, direction);

        boid.CurrentAngle = Mathf.SmoothDampAngle(boid.CurrentAngle, targetAngle, ref boid.angleRef, smoothTime, maxTurnSpeed);
        boid.transform.eulerAngles = new Vector3(0, 0, boid.CurrentAngle);
    }

    void AdaptiveRotationSpeedFollowMouse(Boid boid)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - boid.transform.position;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float targetAngle2 = Vector2.SignedAngle(Vector2.right, direction);
        Debug.Log("atan : " + targetAngle + " | signedAngle : " + targetAngle2);

        // Calculate shortest angle difference
        float angleDifference = Mathf.Abs(Mathf.DeltaAngle(boid.CurrentAngle, targetAngle));

        // Dynamic rotation speed (scale between min and max)
        float dynamicSpeed = Mathf.Lerp(minRotationSpeed, maxRotationSpeed, angleDifference / 180f);

        // Rotate only if the difference is significant
        if (angleDifference > 1f)
        {
            boid.CurrentAngle = Mathf.SmoothDampAngle(boid.CurrentAngle, targetAngle, ref boid.angleRef, 1f / dynamicSpeed);
            boid.transform.rotation = Quaternion.Euler(0, 0, boid.CurrentAngle);
        }
    }
    void AdaptiveRotationToVelocity(Boid boid)
    {
        Vector3 futurePos = boid.transform.position + boid.Velocity;

        Vector3 direction = futurePos - boid.transform.position;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float targetAngle2 = Vector2.SignedAngle(Vector2.right, direction);
        Debug.Log("atan : " + targetAngle + " | signedAngle : " + targetAngle2);

        // Calculate shortest angle difference
        float angleDifference = Mathf.Abs(Mathf.DeltaAngle(boid.CurrentAngle, targetAngle));

        // Dynamic rotation speed (scale between min and max)
        float dynamicSpeed = Mathf.Lerp(minRotationSpeed, maxRotationSpeed, angleDifference / 180f);

        // Rotate only if the difference is significant
        if (angleDifference > 1f)
        {
            boid.CurrentAngle = Mathf.SmoothDampAngle(boid.CurrentAngle, targetAngle, ref boid.angleRef, 1f / dynamicSpeed);
            boid.transform.rotation = Quaternion.Euler(0, 0, boid.CurrentAngle);
        }
    }
}





