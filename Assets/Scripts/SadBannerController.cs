using System.Collections;
using UnityEngine;

public class SadBannerController : MonoBehaviour
{
    [SerializeField] private float pauseTime = 2f;

    private void Start()
    {
        GlobalEvents.PlayerDie.AddListener(ShowBanner);
        GlobalEvents.SadBannerHided.AddListener(RestartCar);
    }
    private void ShowBanner()
    {
        print("ShowBanner");
        GlobalEvents.ShowSadBanner.Invoke();
        GlobalEvents.PauseGame.Invoke();
        StartCoroutine(PauseGame());
    }

    private void HideBanner()
    {
        GlobalEvents.HideSadBanner.Invoke();
    }

    private void RestartCar()
    {
        GlobalEvents.Respawn.Invoke();
        GlobalEvents.ResumeGame.Invoke();
    }

    private IEnumerator PauseGame()
    {
        yield return new WaitForSeconds(pauseTime);
        HideBanner();
    }
}
