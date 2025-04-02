using UnityEngine;

public class ForwardTest : MonoBehaviour
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private bool updateDirection;
    [SerializeField] private float smoothTime;
    [SerializeField] private float maxTurnSpeed = 90;
    private float zVel;
    private Vector3 newRotation;

    float angle;
    float currentVelocity;

    public float minRotationSpeed = 1f;  // Speed when angle is small
    public float maxRotationSpeed = 10f; // Speed when angle is large
    private float angleVelocity = 0f; // SmoothDamp velocity reference

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (updateDirection)
        {
           // CalculateDirection();
            //updateDirection = false;
            followMouse();
            //smoothRotation3();
        }
    }

    private void CalculateDirection()
    {
        Vector3 target = targetPos.position - transform.position;
        //Vector3 rotation = Quaternion.LookRotation(target, Vector3.forward).eulerAngles;
        //followMouse();
        adaptiveRotationSpeedFollowMouse();
        //newRotation = new Vector3(0, 0, Mathf.SmoothDampAngle(newRotation.y, rotation.y, ref zVel, smoothTime));
        //Quaternion current = transform.localRotation;

        //transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        // transform.eulerAngles = newRotation;
        //.forward = dir;
        //transform.LookAt(targetPos.position, Vector3.right);

    }

    void followMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - transform.position;
        float targetAngle = Vector2.SignedAngle(Vector2.right, direction);

        angle = Mathf.SmoothDampAngle(angle, targetAngle, ref currentVelocity, smoothTime, maxTurnSpeed);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void adaptiveRotationSpeedFollowMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - transform.position;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngle = transform.eulerAngles.z;

        // Calculate shortest angle difference
        float angleDifference = Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetAngle));

        // Dynamic rotation speed (scale between min and max)
        float dynamicSpeed = Mathf.Lerp(minRotationSpeed, maxRotationSpeed, angleDifference / 180f);

        // Rotate only if the difference is significant
        if (angleDifference > 1f)
        {
            float newAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref angleVelocity, 1f / dynamicSpeed);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
    }
}
