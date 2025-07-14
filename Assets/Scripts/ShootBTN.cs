using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShootBTN : MonoBehaviour, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Sprite shootSprite;
    [SerializeField] private Sprite defaultSprite;

    private bool isShooting = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        iconImage.sprite = shootSprite;
        isShooting = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isShooting = false;
        iconImage.sprite = defaultSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isShooting = false;
        iconImage.sprite = defaultSprite;
    }
    private void Update()
    {
        if (isShooting == true)
            GlobalEvents.StartShoot.Invoke();
        else
            GlobalEvents.StopShoot.Invoke();
    }
}
