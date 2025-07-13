using UnityEngine;

public class DiePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GlobalEvents.PlayerDie.Invoke();
    }
}
