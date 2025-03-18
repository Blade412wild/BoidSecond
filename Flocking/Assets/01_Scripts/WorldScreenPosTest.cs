using UnityEngine;
using UnityEngine.Rendering;

public class WorldScreenPosTest : MonoBehaviour
{
    private Camera camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos =  camera.WorldToScreenPoint(transform.position);
        Debug.Log("screenPos : " + screenPos);
    }
}
