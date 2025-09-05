using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.back, Time.deltaTime * 33f);
    }
}
