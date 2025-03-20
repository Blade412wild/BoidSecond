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
        if (boid.ScreenPos.x > Screen.width)
        {
            mirrorPos = new Vector2(0, boid.ScreenPos.y);
            boid.ScreenPos = mirrorPos;
        }
        else if (boid.ScreenPos.x < 0)
        {
            mirrorPos = new Vector2(Screen.width, boid.ScreenPos.y);
            boid.ScreenPos = mirrorPos;
        }

        if (boid.ScreenPos.y > Screen.height)
        {
            mirrorPos = new Vector2(boid.ScreenPos.x, 0);
            boid.ScreenPos = mirrorPos;
        }
        else if (boid.ScreenPos.y < 0)
        {
            mirrorPos = new Vector2(boid.ScreenPos.x, Screen.height);
            boid.ScreenPos = mirrorPos;
        }

    }
}
