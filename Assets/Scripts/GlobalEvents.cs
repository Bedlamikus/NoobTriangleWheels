using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : MonoBehaviour
{
    public static UnityEvent Victroy = new();
    public static UnityEvent<Vector3> CheckPoint = new();
    public static UnityEvent PlayerDie = new();

    public static UnityEvent<float> PlayerMove = new();
    public static UnityEvent<float> PlayerRotate = new();
    public static UnityEvent Respawn = new();

    public static UnityEvent StartGame = new();
    public static UnityEvent StartMainMenu = new();

    public static UnityEvent PauseGame = new();
    public static UnityEvent ResumeGame = new();

    public static UnityEvent SpawnTrianglesWheels = new();
    public static UnityEvent SpawnDefaultWheels = new();

    public static UnityEvent StartShoot = new();
    public static UnityEvent StopShoot = new();

    public static UnityEvent ShowSadBanner = new();
    public static UnityEvent SadBannerShowed = new();
    public static UnityEvent SadBannerHided = new();
    public static UnityEvent HideSadBanner = new();
}
