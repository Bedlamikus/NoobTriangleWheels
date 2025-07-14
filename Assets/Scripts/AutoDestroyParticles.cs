using UnityEngine;

public class AutoDestroyParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    void Start()
    {
        float duration = _particleSystem.main.duration + _particleSystem.main.startLifetime.constantMax;
        Destroy(gameObject, duration);
    }
}
