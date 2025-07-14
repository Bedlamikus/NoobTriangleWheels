using System.Collections;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject conffetti;

    private bool isDestroy = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDestroy == true) return;
        var carController2d = collision.GetComponent<CarController2D>();
        if (carController2d == null) return;

        isDestroy = true;
        conffetti.SetActive(true);
        StartCoroutine(VictoryDestroy());
    }

    private IEnumerator VictoryDestroy()
    {
        yield return new WaitForSeconds(5f);
        GlobalEvents.Victroy.Invoke();
        Destroy(this);
    }
}
