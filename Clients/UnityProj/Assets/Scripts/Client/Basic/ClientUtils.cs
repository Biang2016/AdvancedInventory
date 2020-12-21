using BiangLibrary.GameDataFormat.Grid;
using UnityEngine;


public static class ClientUtils
{
    public static GridPos3D ToGridPos3D(this Vector3 vector3)
    {
        return new GridPos3D(Mathf.RoundToInt(vector3.x), Mathf.RoundToInt(vector3.y), Mathf.RoundToInt(vector3.z));
    }
}