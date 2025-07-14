using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float timerDestroy = 2f;

    public float speed;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerDestroy)
        {
            Destroy(gameObject);
        }
        rb.velocity = transform.right * speed * Time.fixedDeltaTime;
    }
}
