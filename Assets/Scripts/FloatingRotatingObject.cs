using UnityEngine;
using System.Collections;

public class FloatingRotatingObject : MonoBehaviour
{
    public float heightDirection = 1f;
    public float speed = 1f;
    public float angularSpeed = 45f;
    public float respawnDelay = 3f;
    [Range(0f, 1f)] public float percentageHiding = 0.3f;
    public bool triangleWheel = true;

    private Vector3 startPos;

    private SpriteRenderer spriteRenderer;
    private Collider2D objectCollider;

    private void Start()
    {
        startPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<Collider2D>();

        StartCoroutine(MoveAndRotate());
    }

    private IEnumerator MoveAndRotate()
    {
        while (true)
        {
            float offsetY = Mathf.Sin(Time.time * speed) * heightDirection;
            transform.position = startPos + new Vector3(0f, offsetY, 0f);
            transform.Rotate(0f, 0f, angularSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CarController2D>() == null) return;

        if (!objectCollider.enabled) return;

        if (triangleWheel == true)
            GlobalEvents.SpawnTrianglesWheels.Invoke();
        else
            GlobalEvents.SpawnDefaultWheels.Invoke();

        StartCoroutine(HandleTrigger());
    }

    private IEnumerator HandleTrigger()
    {
        Color color = spriteRenderer.color;
        color.a = percentageHiding;
        spriteRenderer.color = color;

        objectCollider.enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        color.a = 1f;
        spriteRenderer.color = color;

        objectCollider.enabled = true;
    }
}
