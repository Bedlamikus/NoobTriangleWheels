using UnityEngine;
using UnityEngine.UI;

public class GunButton : MonoBehaviour
{
    [SerializeField] private int gunIndex = 0; // 0 = Gun1, 1 = Gun2, 2 = Gun3, 3 = Gun4
    
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeGun);
    }

    private void ChangeGun()
    {
        Debug.Log($"GunButton: ChangeGun called with gunIndex = {gunIndex}");
        var levelController = FindAnyObjectByType<LevelController>();
        if (levelController != null)
        {
            Debug.Log($"GunButton: LevelController found, calling ChangeGunSprite({gunIndex})");
            levelController.ChangeGun(gunIndex);
        }
        else
        {
            Debug.LogError("GunButton: LevelController not found!");
        }
    }
} 