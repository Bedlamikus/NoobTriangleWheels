using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{

    [SerializeField] private TMP_Text textValue;

    private CoinsService coinsService;

    private void Start()
    {
        coinsService = new CoinsService();
        textValue.text = coinsService.GetCoins.ToString();
        GlobalEvents.UpdateCoins.AddListener(UpdateText);
    }

    private void UpdateText(int value)
    {
        textValue.text = value.ToString();
    }
}
