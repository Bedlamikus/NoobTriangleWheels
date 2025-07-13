using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBG : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier = new Vector2(0.5f, 0.5f);
    [SerializeField] private float smoothSpeed = 10f;

    private Vector3 startPosition;
    private Vector3 cameraStartPosition;
    private Vector3 targetPosition;

    private Transform cameraTransform;

    private void Start()
    {
        var brain = Camera.main.GetComponent<CinemachineBrain>();
        if (brain != null)
            cameraTransform = brain.OutputCamera.transform;
        else
            cameraTransform = Camera.main.transform;

        startPosition = transform.position;
        cameraStartPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 cameraDelta = cameraTransform.position - cameraStartPosition;

        targetPosition = startPosition + new Vector3(
            cameraDelta.x * parallaxEffectMultiplier.x,
            cameraDelta.y * parallaxEffectMultiplier.y,
            0f);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
    
