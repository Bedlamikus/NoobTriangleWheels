using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoin : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float animationTime = 1f;
    [SerializeField] private int countScaleKeys = 4;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Vector3 scaleAxis;

    private void Start()
    {
        StartCoroutine(AnimationTravelRoutine());
        StartCoroutine(AnimationScaleRoutine());
    }

    private IEnumerator AnimationTravelRoutine()
    {
        float timer = 0f;
        float needTime = animationTime * countScaleKeys * 2f;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + direction;

        while (timer <= needTime)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, timer / needTime);
            yield return null;
        }

        Destroy(gameObject);
    }

    private IEnumerator AnimationScaleRoutine()
    {
        for (int i = 0; i < countScaleKeys; i++)
        {
            yield return ScaleRoutine(Vector3.one - scaleAxis.normalized, Vector3.one);
            yield return ScaleRoutine(Vector3.one, Vector3.one - scaleAxis.normalized);
        }
    }

    private IEnumerator ScaleRoutine(Vector3 from, Vector3 to)
    {
        float timer = 0f;
        while (timer < animationTime)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(from, to, animationCurve.Evaluate(timer / animationTime));
            yield return null;
        }
        transform.localScale = to;
    }

}
