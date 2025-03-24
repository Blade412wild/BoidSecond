using UnityEngine;

public class Boid : MonoBehaviour
{
    [field: SerializeField] public bool ShowDebugs { get; private set; }
    public Vector2 ScreenSpacePos;
    public Vector2 WorldSpacePos;
    public Vector3 forwardDir;
    public Vector3 Velocity;
    public float Speed;
    public int Id;

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
