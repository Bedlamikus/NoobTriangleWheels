using UnityEngine;

[System.Serializable]
public class CarSettings
{
    public float motorSpeed = 150f;

    public float boostMultiplier = 2f;
    public KeyCode boostKey = KeyCode.LeftShift;

    public float airRotationTorque = 10f;

    public float maxAngularSpeed = 1000f;
}
