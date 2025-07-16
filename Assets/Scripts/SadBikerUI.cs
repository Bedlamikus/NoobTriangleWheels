using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SadBikerUI : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private AnimationCurve curve;

    private Vector3 startPosition;
    private Vector3 centerPosition;

    private void Start()
    {
        startPosition = transform.position;
        centerPosition = transform.parent.position;
        GlobalEvents.ShowSadBanner.AddListener(Activate);
        GlobalEvents.HideSadBanner.AddListener(Deactivate);
    }

    private void Activate()
    {
        StartCoroutine(MoveTo(centerPosition, GlobalEvents.SadBannerShowed));
    }

    private void Deactivate()
    {
        StartCoroutine (MoveTo(startPosition, GlobalEvents.SadBannerHided));
    }

    private IEnumerator MoveTo(Vector3 position, UnityEvent doEvent)
    {
        var startPosition = transform.position;
        float timer = 0f;
        float needTime = Vector3.Distance(startPosition, position) / speed;
        while (timer < needTime)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, position, curve.Evaluate(timer / needTime));
            yield return null;
        }
        transform.position = position;
        doEvent.Invoke();
    }
}
