using UnityEngine;

public class BoidForwardMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;

    private Vector2 screenPos;
    private Vector2 TargetPos = Vector2.zero;

    private void Start()
    {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
    }

    private void Update()
    {
        CheckIfCrossedBoundry();
        Vector2 dir = Converter.ToVector2(transform.up).normalized;
        screenPos += (dir * speed) * Time.deltaTime;
        TargetPos = Camera.main.ScreenToWorldPoint(screenPos);
        transform.position = TargetPos;
    }

    private void CheckIfCrossedBoundry()
    {
        Vector2 mirrorPos = Vector2.zero;
        if (screenPos.x > Screen.width)
        {
            mirrorPos = new Vector2(0, screenPos.y);
            screenPos = mirrorPos;
        }
        else if (screenPos.x < 0)
        {
            mirrorPos = new Vector2(Screen.width, screenPos.y);
            screenPos = mirrorPos;
        }

        if (screenPos.y > Screen.height)
        {
            mirrorPos = new Vector2(screenPos.x, 0);
            screenPos = mirrorPos;
        }
        else if (screenPos.y < 0)
        {
            mirrorPos = new Vector2(screenPos.x, Screen.height);
            screenPos = mirrorPos;
        }

    }

}
