using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public HingeJoint2D leftWheel;
    public HingeJoint2D rightWheel;

    public void ApplySettings(CarPlatformData data)
    {
        var motor = leftWheel.motor;
        motor.motorSpeed = data.wheelSpeed;
        leftWheel.motor = motor;
        leftWheel.useMotor = true;

        if (data.wheelsSynchronized)
        {
            rightWheel.motor = motor;
        }
        else
        {
            var motor2 = rightWheel.motor;
            motor2.motorSpeed = data.wheelSpeed * Random.Range(0.9f, 1.1f);
            rightWheel.motor = motor2;
        }

        leftWheel.connectedBody.drag = data.drag;
        rightWheel.connectedBody.drag = data.drag;
    }
}
