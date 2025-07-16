using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private FixedJoystick verticalJoystick;
    [SerializeField] private FixedJoystick horizontalJoystick;

    private bool isPause = false;

    private void Start()
    {
        GlobalEvents.PauseGame.AddListener(Pause);
        GlobalEvents.ResumeGame.AddListener(Resume);
    }

    private void Update()
    {
        if (isPause == true) return;

        GlobalEvents.PlayerMove.Invoke(horizontalJoystick.Direction.x);
        GlobalEvents.PlayerRotate.Invoke(verticalJoystick.Direction.y);
    }

    private void Pause()
    {
        isPause = true;
    }

    private void Resume()
    {
        isPause = false;
    }
}
