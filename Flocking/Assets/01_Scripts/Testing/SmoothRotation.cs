using UnityEngine;

public class SmoothRotation : MonoBehaviour
{
    public bool updateRotation;
    public bool updateVelocity;

    [Space]
    public Vector2 Velocity;
    public float targetAngle;
    public bool useVelocity;

    [Space]
    public Boid boid;

    private float r;
    private Vector2 targetVelocity;

    private void Start()
    {
        targetVelocity = Velocity;
    }

    void Update()
    {
        if (updateVelocity)
        {
            targetVelocity = Velocity;
            updateVelocity = false;
            Debug.Log(targetVelocity);
        }

        if (updateRotation)
        {
            float targetAngle;
            if (useVelocity)
            {
                targetAngle = Mathf.Atan2(targetVelocity.y, targetVelocity.x) * Mathf.Rad2Deg;
                Debug.Log(targetAngle);
            }
            else
            {
                targetAngle = this.targetAngle;
            }

            float angle = Mathf.SmoothDampAngle(boid.transform.eulerAngles.z, targetAngle, ref r, 0.1f);

            boid.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }


}
