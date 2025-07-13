using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform platformAnchor;
    private GameObject currentPlatform;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SwitchToPlatform(CarPlatformData data)
    {
        if (currentPlatform != null)
            Destroy(currentPlatform);

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);

        currentPlatform = Instantiate(data.platformPrefab, platformAnchor.position, Quaternion.identity, platformAnchor);

        var platformController = currentPlatform.GetComponent<PlatformController>();
        platformController.ApplySettings(data);
    }
}

