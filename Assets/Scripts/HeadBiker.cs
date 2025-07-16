using UnityEngine;

public class HeadBiker : MonoBehaviour
{
    private bool isPause = false;

    private void Start()
    {
        GlobalEvents.PauseGame.AddListener(Pause);
        GlobalEvents.ResumeGame.AddListener(Resume);
        GlobalEvents.Victroy.AddListener(Pause);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<CarController2D>();
        if (isPause == true || player != null) return;

        GlobalEvents.PlayerDie.Invoke();
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
