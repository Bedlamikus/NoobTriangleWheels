using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private FixedJoystick verticalJoystick;
    [SerializeField] private FixedJoystick horizontalJoystick;

    private void Update()
    {
        GlobalEvents.PlayerMove.Invoke(horizontalJoystick.Direction.x);
        GlobalEvents.PlayerRotate.Invoke(verticalJoystick.Direction.y);
    }
}
