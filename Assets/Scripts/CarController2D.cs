using UnityEngine;

public class CarController2D : MonoBehaviour
{
    public Rigidbody2D carBody;
    public WheelController2D leftWheel;
    public WheelController2D rightWheel;

    public SpriteRenderer coloredBack;
    public SpriteRenderer carBodySprite;

    [Header("Vehicle Sprites")]
    public Sprite[] vehicleSprites = new Sprite[4]; // Vehicle1, Vehicle2, Vehicle3, Vehicle4

    [Header("Gun Sprites")]
    public Sprite[] gunSprites = new Sprite[4]; // Gun1, Gun2, Gun3, Gun4

    private float moveInput;
    private float rotateInput;
    private bool isBoosting;
    private bool freeze = false;

    private void Start()
    {
        SetVehicleSprite(GetVehicleIndex());
        SetGunSprite(GetGunIndex());
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

    public void SetColor(Color newColor)
    {
        // Устаревший метод - теперь используется SetVehicleSprite
        coloredBack.color = newColor;
    }

    public void SetVehicleSprite(int vehicleIndex)
    {
        Debug.Log($"CarController2D: SetVehicleSprite called with vehicleIndex = {vehicleIndex}");
        Debug.Log($"CarController2D: vehicleSprites.Length = {vehicleSprites.Length}");
        Debug.Log($"CarController2D: carBodySprite = {(carBodySprite != null ? "not null" : "null")}");
        
        if (vehicleIndex >= 0 && vehicleIndex < vehicleSprites.Length && vehicleSprites[vehicleIndex] != null)
        {
            Debug.Log($"CarController2D: Setting sprite to vehicleSprites[{vehicleIndex}]");
            carBodySprite.sprite = vehicleSprites[vehicleIndex];
            SaveVehicleIndex(vehicleIndex);
        }
        else
        {
            Debug.LogError($"CarController2D: Invalid vehicleIndex {vehicleIndex} or sprite is null!");
        }
    }

    private void SaveVehicleIndex(int vehicleIndex)
    {
        PlayerPrefs.SetInt("VEHICLE_INDEX", vehicleIndex);
        PlayerPrefs.Save();
    }

    private int GetVehicleIndex()
    {
        return PlayerPrefs.GetInt("VEHICLE_INDEX", 0);
    }

    public void SetGunSprite(int gunIndex)
    {
        Debug.Log($"CarController2D: SetGunSprite called with gunIndex = {gunIndex}");
        Debug.Log($"CarController2D: gunSprites.Length = {gunSprites.Length}");
        
        if (gunIndex >= 0 && gunIndex < gunSprites.Length && gunSprites[gunIndex] != null)
        {
            Debug.Log($"CarController2D: Setting gun sprite to gunSprites[{gunIndex}]");
            
            // Находим объект Gun в дочерних объектах
            Transform gunTransform = transform.Find("Gun");
            if (gunTransform != null)
            {
                SpriteRenderer gunSpriteRenderer = gunTransform.GetComponent<SpriteRenderer>();
                if (gunSpriteRenderer != null)
                {
                    gunSpriteRenderer.sprite = gunSprites[gunIndex];
                    SaveGunIndex(gunIndex);
                }
                else
                {
                    Debug.LogError("CarController2D: Gun SpriteRenderer not found!");
                }
            }
            else
            {
                Debug.LogError("CarController2D: Gun object not found!");
            }
        }
        else
        {
            Debug.LogError($"CarController2D: Invalid gunIndex {gunIndex} or sprite is null!");
        }
    }

    private void SaveGunIndex(int gunIndex)
    {
        PlayerPrefs.SetInt("GUN_INDEX", gunIndex);
        PlayerPrefs.Save();
    }

    private int GetGunIndex()
    {
        return PlayerPrefs.GetInt("GUN_INDEX", 0);
    }
}
