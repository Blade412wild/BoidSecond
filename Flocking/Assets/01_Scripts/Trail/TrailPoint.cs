using System;
using UnityEngine;

public class TrailPoint : MonoBehaviour
{
    public Action TrailPointCompleted;

    public int Id;
    [field: SerializeField] public float boidsNeededToSwitch { get; private set; }
    [SerializeField] private Renderer renderer;

    private TrailManager trailManager;

    public void Init(TrailManager manager, int id)
    {
        Id = id;
        trailManager = manager;

    }

    public void ChangeColor(Color color)
    {
        renderer.material.color = color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);

        if (other.TryGetComponent(out Boid boid))
        { 
            trailManager.OnBoidReachingTrailPoint(this);
        }

    }


}



