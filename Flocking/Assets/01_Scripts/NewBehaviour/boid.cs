using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 ScreenPos;
    public Vector3 forwardDir;
    public Vector3 Velocity;
    public float Speed;

    public void Init(float speed)
    {
        Speed = speed;
        Velocity = transform.up;
        ScreenPos = Camera.main.WorldToScreenPoint(transform.position);

    }

    private void Update()
    {
        forwardDir = transform.up;
    }
}
