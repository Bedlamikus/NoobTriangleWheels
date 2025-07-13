using UnityEngine;
using UnityEngine.UI;

public class RespawnBtn : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

    private void Click()
    {
        GlobalEvents.Respawn.Invoke();
    }
}
