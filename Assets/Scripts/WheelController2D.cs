using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WheelController2D : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyDrive(float direction, bool boost, CarSettings settings)
    {
        if (direction == 0f)
        {
            rb.angularVelocity *= 0.98f;
            return;
        }

        float currentSpeed = settings.motorSpeed;
        if (boost)
        {
            currentSpeed *= settings.boostMultiplier;
        }

        if (Mathf.Abs(rb.angularVelocity) < settings.maxAngularSpeed)
        {
            rb.AddTorque(-direction * currentSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }

    public bool IsTouchingGround()
    {
        return rb.IsTouchingLayers();
    }
}
