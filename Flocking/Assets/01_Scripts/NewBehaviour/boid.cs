using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector2 ScreenSpacePos;
    public Vector2 WorldSpacePos;
    public Vector3 forwardDir;
    public Vector3 Velocity;
    public float Speed;

    public void Init(float speed)
    {
        Speed = speed;
        Velocity = transform.up;
        ScreenSpacePos = Camera.main.WorldToScreenPoint(transform.position);
        WorldSpacePos = transform.position;

    }

    private void Update()
    {
        forwardDir = transform.up;
    }
}
