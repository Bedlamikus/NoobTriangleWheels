using System.Collections;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float animationSpeed;
    [SerializeField] private GameObject flag;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated == true) return;

        activated = true;
        StartCoroutine(Activate());
        GlobalEvents.CheckPoint.Invoke(transform.position);
    }

    private IEnumerator Activate()
    {
        float startAngle = flag.transform.localEulerAngles.z;
        float endAngle = 0f;
        float needTime = Mathf.Abs(startAngle - endAngle) / animationSpeed;
        float timer = 0;
        while (timer < needTime)
        {
            timer += Time.deltaTime;
            float zAngle = Mathf.LerpAngle(startAngle, endAngle, animationCurve.Evaluate(timer / needTime));
            flag.transform.localEulerAngles = new Vector3(
                transform.localEulerAngles.x,
                transform.localEulerAngles.y,
                zAngle);
            yield return null;
        }
    }
}
