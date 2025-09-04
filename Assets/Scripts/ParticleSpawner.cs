using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] ParticleSystem particlePrefab;

    private void Start()
    {
        GlobalEvents.SpawnParticle.AddListener(SpawnParticles);
    }

    private void SpawnParticles(Color color, Vector3 position)
    {
        print("Try spawn particle");
        var particle = Instantiate(particlePrefab);
        //particle.transform.localEulerAngles = Vector3.left * 180;
        var main = particle.main;
        main.startColor = color;
        particle.Play();
        particle.transform.SetParent(transform);
        particle.transform.position = position;
    }
}
