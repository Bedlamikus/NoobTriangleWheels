using UnityEngine;

public class DiePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Try player die");
        var player = collision.GetComponent<CarController2D>();
        if (player == null) return;
        print("Try player die event");
        GlobalEvents.PlayerDie.Invoke();
    }
}
