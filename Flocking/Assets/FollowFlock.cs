using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class FollowFlock : MonoBehaviour
{
    [SerializeField] private FlockManager manager;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private bool followFlock;
    [SerializeField] private float distance;
    private Vector2 middlePoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        distance = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (followFlock)
        {
            Camera.main.orthographicSize = distance;
            CalculateMiddlePoint(manager.boids);
            transform.position = new Vector3(middlePoint.x, middlePoint.y, transform.position.z);
        }
        else
        {
            transform.position = startPos;
        }
    }

    private void CalculateMiddlePoint(List<Boid> otherBoids)
    {
        middlePoint = Vector2.zero;

        foreach (Boid otherBoid in otherBoids)
        {
            if (middlePoint == Vector2.zero)
            {
                middlePoint = otherBoid.WorldSpacePos;
            }
            else
            {
                middlePoint += otherBoid.WorldSpacePos;
            }
        }
         middlePoint = middlePoint / otherBoids.Count;
    }
}
