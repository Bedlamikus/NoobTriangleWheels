using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int currentLevel
    {
        get
        {
            return PlayerPrefs.GetInt("LEVEL", 1);
        }
        set
        {
            PlayerPrefs.SetInt("LEVEL", value);
            PlayerPrefs.Save();
        }
    }

    public CarSettings settings;

    public Car carPrefabDefaultWheels;

    public Car currentPrefab;

    public Transform spawnTransform;
    public Vector3 checkPoint;

    private Car currentCar;

    public static LevelController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        GlobalEvents.Victroy.AddListener(LoadNextLevel);
        GlobalEvents.CheckPoint.AddListener(SetCheckPoint);
        GlobalEvents.PlayerDie.AddListener(RespawnCar);
        GlobalEvents.Respawn.AddListener(RespawnCar);
        GlobalEvents.StartGame.AddListener(StartGame);
        GlobalEvents.StartMainMenu.AddListener(LoadMainMenu);
        GlobalEvents.SpawnDefaultWheels.AddListener(SpawnDefaultCar);
    }

    private void Start()
    {
        // Всегда начинаем с вагонетки (CarDefaultWheel)
        currentPrefab = carPrefabDefaultWheels;
        checkPoint = spawnTransform.position;
        SpawnCarAt(checkPoint, spawnTransform.rotation);
    }

    public void SpawnCar()
    {
        SpawnCarAt(checkPoint, spawnTransform.rotation);
    }

    public void RespawnCar()
    {
        // Всегда респауним вагонетку (CarDefaultWheel)
        currentPrefab = carPrefabDefaultWheels;
        
        DestroyCar();
        SpawnCarAt(checkPoint, Quaternion.identity);
    }

    private void DestroyCar()
    {
        if (currentCar != null)
        {
            Destroy(currentCar.gameObject);
            currentCar = null;
        }
    }

    public Rigidbody2D GetCarRigidbody()
    {
        if (currentCar != null)
        {
            return currentCar.bodyRigidBody;
        }
        return null;
    }

    private void SpawnCarAt(Vector3 position, Quaternion rotation)
    {
        currentCar = Instantiate(currentPrefab, position, rotation);
    }



    private void LoadNextLevel()
    {
        currentLevel++;
        if (currentLevel >= SceneManager.sceneCountInBuildSettings)
            currentLevel = 1;
        SceneManager.LoadScene(currentLevel);
    }

    private void SetCheckPoint(Vector3 point)
    {
        checkPoint = point;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(currentLevel);
    }

    private void SpawnDefaultCar()
    {
        currentPrefab = carPrefabDefaultWheels;
        var position = currentCar.bodyRigidBody.transform.position;
        var rotation = currentCar.bodyRigidBody.transform.rotation;
        DestroyCar();
        SpawnCarAt(position, rotation);
    }
}
