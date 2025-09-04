using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float animationTime = 1f;
    [SerializeField] private Transform directionPoint;

    private void Start()
    {
        StartCoroutine(AnimationTravelRoutine());
    }

    private IEnumerator AnimationTravelRoutine()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = directionPoint.position;

        while (true)
        {
            yield return MoveRoutine(startPosition, endPosition);
            yield return MoveRoutine(endPosition, startPosition);
        }
    }

    private IEnumerator MoveRoutine(Vector3 from, Vector3 to)
    {
        float timer = 0f;
        while (timer < animationTime)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(from, to, animationCurve.Evaluate(timer / animationTime));
            yield return null;
        }
        transform.position = to;
    }
}
