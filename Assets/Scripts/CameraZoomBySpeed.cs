using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraZoomBySpeed : MonoBehaviour
{
    public float minZoom = 5f;
    public float maxZoom = 8f;
    public float maxSpeed = 20f;
    public float zoomLerpSpeed = 2f;

    private CinemachineVirtualCamera vcam;
    private float currentZoom;
    private Rigidbody2D targetRigidbody;

    private void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        currentZoom = minZoom;
    }

    private void Update()
    {
        if (targetRigidbody == null)
        {
            targetRigidbody = LevelController.Instance?.GetCarRigidbody();
            if (targetRigidbody == null) return;
        }

        vcam.Follow = targetRigidbody.transform;

        float speed = targetRigidbody.velocity.magnitude;

        float targetZoom = Mathf.Lerp(minZoom, maxZoom, speed / maxSpeed);
        currentZoom = Mathf.Lerp(currentZoom, targetZoom, Time.deltaTime * zoomLerpSpeed);

        vcam.m_Lens.OrthographicSize = currentZoom;
    }
}
