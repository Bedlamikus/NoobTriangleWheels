using UnityEngine;

public class CarController2D : MonoBehaviour
{
    public Rigidbody2D carBody;
    public WheelController2D leftWheel;
    public WheelController2D rightWheel;

    private float moveInput;
    private float rotateInput;
    private bool isBoosting;
    private bool freeze = false;

    private void Start()
    {
        if (freeze == true) return;

        GlobalEvents.PlayerMove.AddListener(SetDirection);
        GlobalEvents.PlayerRotate.AddListener(SetRotation);
    }

    public void Freeze()
    {
        freeze = true;
    }

    private void Update()
    {
        if (freeze == true) return;
        isBoosting = Input.GetKey(LevelController.Instance.settings.boostKey);
    }

    private void SetDirection(float direction)
    {
        if (freeze == true) return;
        moveInput = direction;
        if (Input.GetKey(KeyCode.A)) moveInput = -1f;
        else if (Input.GetKey(KeyCode.D)) moveInput = 1f;
    }

    private void SetRotation(float rotation)
    {
        if (freeze == true) return;
        rotateInput = rotation;
        if (Input.GetKey(KeyCode.W)) rotateInput = 1f;
        else if (Input.GetKey(KeyCode.S)) rotateInput = -1f;
    }

    private void FixedUpdate()
    {
        if (freeze == true) return;
        leftWheel.ApplyDrive(moveInput, isBoosting, LevelController.Instance.settings);
        rightWheel.ApplyDrive(moveInput, isBoosting, LevelController.Instance.settings);

        carBody.AddTorque(rotateInput * LevelController.Instance.settings.airRotationTorque);
    }
}
