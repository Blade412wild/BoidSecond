using UnityEngine;
public static class Converter
{
    public static Vector2 ToVector2(Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }


}

