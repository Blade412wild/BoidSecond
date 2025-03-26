using UnityEngine;

public class Boid : MonoBehaviour
{
    [field: SerializeField] public bool ShowDebugs { get; private set; }
    public Transform Art;

    [HideInInspector] public Vector2 ScreenSpacePos;
    [HideInInspector] public Vector2 WorldSpacePos;
    [HideInInspector] public Vector3 forwardDir;
    [HideInInspector] public Vector3 Velocity;
    [HideInInspector] public float Speed;
    [HideInInspector] public int Id;
    [HideInInspector] public float CurrentAngle;
    [HideInInspector] public float AngleVelocity;
    [HideInInspector] public float angleRef;
    [HideInInspector] public int RotationIterationCounter;
    public void Init(float speed, int id)
    {
        Speed = speed;
        Velocity = transform.up;
        ScreenSpacePos = Camera.main.WorldToScreenPoint(transform.position);
        WorldSpacePos = transform.position;
        Id = id;
    }

    private void Update()
    {
        forwardDir = transform.up;
    }
}
