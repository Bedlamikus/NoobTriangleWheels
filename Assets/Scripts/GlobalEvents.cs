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

    public static UnityEvent SpawnTrianglesWheels = new();
    public static UnityEvent SpawnDefaultWheels = new();

    public static UnityEvent StartShoot = new();
    public static UnityEvent StopShoot = new();

    public static UnityEvent<int> AddCoins = new();
    public static UnityEvent<int> SpendCoins = new();
    public static UnityEvent<int> SpendCoinsError = new();
    public static UnityEvent<int> SpendCoinsSucces = new();
    public static UnityEvent<int> UpdateCoins = new();

    public static UnityEvent<Vector3> SpawnDropCoin = new();
    public static UnityEvent<Color, Vector3> SpawnParticle = new();
}
