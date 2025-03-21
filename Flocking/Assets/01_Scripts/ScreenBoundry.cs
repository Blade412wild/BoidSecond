using UnityEngine;

public static class ScreenBoundry
{
    public static void CheckIfCrossedBoundry(Boid boid)
    {
        boid.ScreenSpacePos = Camera.main.WorldToScreenPoint(boid.transform.position);

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

        boid.WorldSpacePos = Camera.main.ScreenToWorldPoint(boid.ScreenSpacePos);
        boid.transform.position = boid.WorldSpacePos;
    }
}
