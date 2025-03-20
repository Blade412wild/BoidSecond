using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool randomGeneration;
    [SerializeField] private int amountBoids;

    [Space]
    [SerializeField] private bool UpdatePosition;
    [SerializeField] private bool showFullVelocity;

    [Header("Cohesion")]
    [SerializeField] private bool showMiddlePointVelocity;

    [Header("Allignment")]
    [SerializeField] private bool showAllignmentVelocity;



    [Header("Refs")]
    [SerializeField] private List<FlockBehaviourBase> ruleList;
    [SerializeField] private List<Boid> boids;
    [SerializeField] private Boid boidPrefab;

    private int counter = 0;
    private void Start()
    {
        if (randomGeneration)
        {
            GenerateRandomBoids();
        }

        InitializeBoids();

    }

    private void Update()
    {
        if (!UpdatePosition) return;
        CalculateNewPosition();
    }

    private void CalculateNewPosition()
    {
        foreach (Boid boid in boids)
        {
            Vector3 newVelocity = boid.Velocity;
            foreach (FlockBehaviourBase rule in ruleList)
            {
                newVelocity += rule.CalculateVelocity(boid, boids);
            }

            //Quaternion direction = Quaternion.identity;
            //direction.eulerAngles = new Vector3(0, 0, boid.Velocity.normalized.y);

            boid.Velocity = (newVelocity * Time.deltaTime);
            Vector3 velocity3D = new Vector3(boid.Velocity.x, boid.Velocity.y, 0);
            boid.transform.position += velocity3D;

            ScreenBoundry.CheckIfCrossedBoundry(boid);

        }
    }

    private void GenerateRandomBoids()
    {
        ClearAndDestoryList(boids);

        for (int i = 0; i < amountBoids; i++)
        {
            Vector2 randomPos = GetRandomPosition(Screen.width, Screen.height, 100);
            Quaternion randomRotation = GetRandomRotation();

            Boid boid = Instantiate(boidPrefab, randomPos, randomRotation);
            boids.Add(boid);
        }
    }

    private void InitializeBoids()
    {
        foreach (Boid boid in boids)
        {
            //float speed = Random.Range(1, 5);
            boid.Init(1);
        }
    }

    private Vector2 GetRandomPosition(float x, float y, float BorderMarging)
    {

        Vector2 screenPos = Vector2.zero;

        float randomX = Random.Range(0 + BorderMarging, x - BorderMarging);
        float randomY = Random.Range(0 + BorderMarging, y - BorderMarging);

        screenPos = Camera.main.ScreenToWorldPoint(new Vector2(randomX, randomY));


        return screenPos;
    }

    private Quaternion GetRandomRotation()
    {
        float randomRotationZ = Random.Range(0, 360);
        Quaternion randomRotation = Quaternion.identity;
        randomRotation.eulerAngles = new Vector3(0, 0, randomRotationZ);

        return randomRotation;
    }

    private void ClearAndDestoryList<T>(List<T> list) where T : MonoBehaviour
    {
        foreach (var item in list)
        {
            Destroy(item.gameObject);
        }

        list.Clear();
    }

}


