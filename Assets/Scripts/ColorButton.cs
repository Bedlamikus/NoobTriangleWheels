using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    [SerializeField] private int vehicleIndex = 0; // 0 = Vehicle1, 1 = Vehicle2, 2 = Vehicle3, 3 = Vehicle4
    
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeVehicle);
    }

    private void ChangeVehicle()
    {
        Debug.Log($"ColorButton: ChangeVehicle called with vehicleIndex = {vehicleIndex}");
        var levelController = FindAnyObjectByType<LevelController>();
        if (levelController != null)
        {
            levelController.ChangeVehicleSprite(vehicleIndex);
        }
        else
        {
            Debug.LogError("ColorButton: LevelController not found!");
        }
    }
}
