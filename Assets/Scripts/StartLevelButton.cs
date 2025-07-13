using UnityEngine;
using UnityEngine.UI;

public class StartLevelButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

    private void Click()
    {
        GlobalEvents.StartGame.Invoke();
    }
}
