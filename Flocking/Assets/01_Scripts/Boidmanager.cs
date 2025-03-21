using Mono.Cecil;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Boidmanager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool rule1;
    [SerializeField] private bool rule2;
    [SerializeField] private bool rule3;
    private float speed = 300.0f;


    [Header("Refs")]
    [SerializeField] private List<Boid> boids;

    private void Start()
    {
       foreach (Boid boid in boids)
        {
            //boid.Init();
        }
    }

    private void Update()
    {
        //for(int i = 0; i < boids.Count; i++)
        //{
        //    Boid boid = boids[i];

        //    Vector3 targetDir = Vector3.zero;
        //    if(rule1 == true)
        //    {

        //        for (int j = 0; j < boids.Count; j++)
        //        {
        //            if (boid == boids[j]) continue;
        //            targetDir += boids[j].forwardDir;
        //        }

        //        targetDir = targetDir / (boids.Count - 1.0f);
        //    }
        //    else
        //    {
        //        targetDir = boids[i].forwardDir;
        //    }
           
        //    CheckIfCrossedBoundry(boid);
            

        //    boid.ScreenPos += (targetDir * speed) * Time.deltaTime;
        //    Vector2 targetPos = Camera.main.ScreenToWorldPoint(boid.ScreenPos);
        //    boid.transform.position = targetPos;
        //}
    }
    private void CheckIfCrossedBoundry(Boid boid)
    {
        Vector2 mirrorPos = Vector2.zero;
        if (boid.ScreenSpacePos.x > Screen.width)
        {
            mirrorPos = new Vector2(0, boid.ScreenSpacePos.y);
            boid.ScreenSpacePos = mirrorPos;
        }
        else if (boid.ScreenSpacePos.x < 0)
        {
            mirrorPos = new Vector2(Screen.width, boid.ScreenSpacePos.y);
            boid.ScreenSpacePos = mirrorPos;
        }

        if (boid.ScreenSpacePos.y > Screen.height)
        {
            mirrorPos = new Vector2(boid.ScreenSpacePos.x, 0);
            boid.ScreenSpacePos = mirrorPos;
        }
        else if (boid.ScreenSpacePos.y < 0)
        {
            mirrorPos = new Vector2(boid.ScreenSpacePos.x, Screen.height);
            boid.ScreenSpacePos = mirrorPos;
        }

    }
}
