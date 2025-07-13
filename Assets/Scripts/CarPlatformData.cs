using UnityEngine;

[CreateAssetMenu(fileName = "PlatformData", menuName = "Car/Platform Data")]
public class CarPlatformData : ScriptableObject
{
    public GameObject platformPrefab;
    public bool wheelsSynchronized;
    public float wheelSpeed;
    public float grip;
    public float drag;
}
