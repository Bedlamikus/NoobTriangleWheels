using UnityEngine;

[CreateAssetMenu(fileName = "GunSettings", menuName = "ScriptableObjects/GunSettings", order = 1)]
public class GunSettings : ScriptableObject
{
    public float bulletSpeed = 100f;
    public float cooldownBeetwenBullets = 0.3f;
    public int countBulletsPerTime = 1;
    public float cooldownBeetwenShooting = 3f;
}