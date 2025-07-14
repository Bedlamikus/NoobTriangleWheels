using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody2D bodyRigidBody;

    public void Freeze()
    {
        var controller = GetComponentInChildren<CarController2D>();
        controller.Freeze();
    }

    public void ChangeVehicleSprite(int vehicleIndex)
    {
        Debug.Log($"Car: ChangeVehicleSprite called with vehicleIndex = {vehicleIndex}");
        var controller = GetComponentInChildren<CarController2D>();
        if (controller != null)
        {
            Debug.Log($"Car: Calling controller.SetVehicleSprite({vehicleIndex})");
            controller.SetVehicleSprite(vehicleIndex);
        }
        else
        {
            Debug.LogError("Car: CarController2D not found!");
        }
    }

    public void ChangeGunSprite(int gunIndex)
    {
        Debug.Log($"Car: ChangeGunSprite called with gunIndex = {gunIndex}");
        var controller = GetComponentInChildren<CarController2D>();
        if (controller != null)
        {
            Debug.Log($"Car: Calling controller.SetGunSprite({gunIndex})");
            controller.SetGunSprite(gunIndex);
        }
        else
        {
            Debug.LogError("Car: CarController2D not found!");
        }
    }
}
