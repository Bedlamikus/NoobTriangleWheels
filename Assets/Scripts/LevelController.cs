using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int currentLevel
    {
        get
        {
            return PlayerPrefs.GetInt("LEVEL", 0);
        }
        set
        {
            PlayerPrefs.SetInt("LEVEL", value);
            PlayerPrefs.Save();
        }
    }

    public CarSettings settings;

    public Car carPrefabDefaultWheels;
    public Car carPrefabTriangleWheels;

    public Car currentPrefab;

    public Transform spawnTransform;
    public Vector3 checkPoint;

    private Car currentCar;

    public static LevelController Instance { get; private set; }

    [SerializeField] private bool mainMenu = false;

    [SerializeField] private int savedVehicleIndex;
    [SerializeField] private int savedGunIndex;

    private bool triangleWheels
    {
        get
        {
            return PlayerPrefs.GetInt("TRIANGLE", 0) == 1;
        }
        set
        {
            PlayerPrefs.SetInt("TRIANGLE", value == true ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        LoadLevelIndex(currentLevel);

        GlobalEvents.Victroy.AddListener(LoadNextLevel);
        GlobalEvents.CheckPoint.AddListener(SetCheckPoint);
        GlobalEvents.PlayerDie.AddListener(RespawnCar);
        GlobalEvents.Respawn.AddListener(RespawnCar);
        GlobalEvents.StartGame.AddListener(StartGame);
        GlobalEvents.StartMainMenu.AddListener(LoadMainMenu);
        GlobalEvents.SpawnTrianglesWheels.AddListener(SpawnTriangleCar);
        GlobalEvents.SpawnDefaultWheels.AddListener(SpawnDefaultCar);

        triangleWheels = false;
    }

    private void Start()
    {
        // Всегда начинаем с вагонетки (CarDefaultWheel)
        currentPrefab = carPrefabDefaultWheels;
        triangleWheels = false;
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
        triangleWheels = false;
        
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

        // Всегда меняем спрайт на выбранный
        //int savedVehicleIndex = PlayerPrefs.GetInt("VEHICLE_INDEX", 0);
        currentCar.ChangeVehicleSprite(savedVehicleIndex);

        // Всегда меняем спрайт оружия на выбранный
        //int savedGunIndex = PlayerPrefs.GetInt("GUN_INDEX", 0);
        currentCar.ChangeGunSprite(savedGunIndex);

        if (mainMenu == true)
            currentCar.Freeze();
    }

    private void LoadLevelIndex(int index)
    {
        if (index >= SceneManager.sceneCountInBuildSettings)
        {
            currentLevel = 0;
            index = 0;
            print($"LoadLevelIndex({index})");
            print($"currentLevel = {currentLevel}");
            SceneManager.LoadScene(index);
        }
    }

    private void LoadNextLevel()
    {
        currentLevel++;
        if (currentLevel >= SceneManager.sceneCountInBuildSettings)
            currentLevel = 0;
        SceneManager.LoadScene(currentLevel);
    }

    private void SetCheckPoint(Vector3 point)
    {
        checkPoint = point;
    }

    public void ChangeVehicleSprite(int vehicleIndex)
    {
        Debug.Log($"LevelController: ChangeVehicleSprite called with vehicleIndex = {vehicleIndex}");
        
        //PlayerPrefs.SetInt("VEHICLE_INDEX", vehicleIndex);
        //PlayerPrefs.Save();
        
        if (currentCar != null)
        {
            Debug.Log($"LevelController: Calling currentCar.ChangeVehicleSprite({vehicleIndex})");
            currentCar.ChangeVehicleSprite(vehicleIndex);
        }
        else
        {
            Debug.LogWarning("LevelController: currentCar is null!");
        }
    }

    public void ChangeGun(int gunIndex)
    {
        Debug.Log($"LevelController: ChangeGunSprite called with gunIndex = {gunIndex}");
        
        //PlayerPrefs.SetInt("GUN_INDEX", gunIndex);
        //PlayerPrefs.Save();
        
        if (currentCar != null)
        {
            Debug.Log($"LevelController: Calling currentCar.ChangeGunSprite({gunIndex})");
            currentCar.ChangeGunSprite(gunIndex);
        }
        else
        {
            Debug.LogWarning("LevelController: currentCar is null!");
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(currentLevel);
    }

    private void SpawnTriangleCar()
    {
        if (triangleWheels == true) return;
        currentPrefab = carPrefabTriangleWheels;
        triangleWheels = true;
        var position = currentCar.bodyRigidBody.transform.position;
        var rotation = currentCar.bodyRigidBody.transform.rotation;
        DestroyCar();
        SpawnCarAt(position, rotation);
    }
    private void SpawnDefaultCar()
    {
        if (triangleWheels == false) return;
        currentPrefab = carPrefabDefaultWheels;
        triangleWheels = false;
        var position = currentCar.bodyRigidBody.transform.position;
        var rotation = currentCar.bodyRigidBody.transform.rotation;
        DestroyCar();
        SpawnCarAt(position, rotation);
    }
}
