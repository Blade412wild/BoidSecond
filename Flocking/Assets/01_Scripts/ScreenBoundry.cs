using UnityEngine;

public static class ScreenBoundry
{
    public static void CheckIfCrossedBoundry(Boid boid)
    {
        boid.ScreenPos = Camera.main.WorldToScreenPoint(boid.transform.position);

        Vector3 mirrorPos = Vector3.zero;
        if (boid.ScreenPos.x > Screen.width)
        {
            mirrorPos = new Vector3(0, boid.ScreenPos.y);
            boid.ScreenPos = mirrorPos;
        }
        else if (boid.ScreenPos.x < 0)
        {
            mirrorPos = new Vector3(Screen.width, boid.ScreenPos.y);
            boid.ScreenPos = mirrorPos;
        }

        if (boid.ScreenPos.y > Screen.height)
        {
            mirrorPos = new Vector3(boid.ScreenPos.x, 0);
            boid.ScreenPos = mirrorPos;
        }
        else if (boid.ScreenPos.y < 0)
        {
            mirrorPos = new Vector3(boid.ScreenPos.x, Screen.height);
            boid.ScreenPos = mirrorPos;
        }


        boid.transform.position = Camera.main.ScreenToWorldPoint(boid.ScreenPos);
    }
}
