using UnityEngine;

public struct TransformData
{
    public Vector3 Position;
    public Quaternion Rotation;
    
    public TransformData(Transform transform)
    {
        Position = transform.position;
        Rotation = transform.rotation;
    }
}