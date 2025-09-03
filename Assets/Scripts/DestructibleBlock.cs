using UnityEngine;

public class DestructibleBlock : MonoBehaviour
{
    [SerializeField] private int price = 11;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private int countDestructLevels = 3;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ParticleSystem _particleSystem;

    private int currentLevel = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var projectile = collision.GetComponent<Projectile>();
        if (projectile == null) return;

        ApplyDamage();
    }

    public void ApplyDamage()
    {
        if (currentLevel < countDestructLevels - 1)
        {
            currentLevel++;
            _spriteRenderer.sprite = sprites[currentLevel];
        }
        else
        {
            GlobalEvents.AddCoins.Invoke(price);

            _particleSystem.gameObject.SetActive(true);
            _particleSystem.gameObject.transform.SetParent(null);
            _particleSystem.Play();

            Destroy(gameObject);
        }
    }
}
