using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private GunSettings settings;

    private bool isShoot = false;

    private void Start()
    {
        GlobalEvents.StartShoot.AddListener(StartShoot);
        GlobalEvents.StopShoot.AddListener(StopSoot);
        StartCoroutine(LifeCycle());
    }

    private void StartShoot()
    {
        isShoot = true;
    }

    private void StopSoot()
    {
        isShoot = false;
    }

    private IEnumerator LifeCycle()
    { 
        while (true)
        {
            if (isShoot == true)
            {
                for (int i = 0; i < settings.countBulletsPerTime; i++)
                {
                    if (isShoot == false) continue;
                    SpawnBullet();
                    if (i < settings.countBulletsPerTime - 1)
                        yield return new WaitForSeconds(settings.cooldownBeetwenBullets);
                }
                if (isShoot == true)
                    yield return new WaitForSeconds(settings.cooldownBeetwenShooting);
            }
            yield return null;
        }
    }

    private void SpawnBullet()
    {
        var projectile = Instantiate(projectilePrefab);
        projectile.transform.position = shootPoint.position;
        projectile.transform.rotation = shootPoint.rotation;
        projectile.speed = settings.bulletSpeed;
    }
}
