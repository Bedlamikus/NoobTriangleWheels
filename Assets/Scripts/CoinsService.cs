using UnityEngine;

public class CoinsService
{
    private const string saveName = "COINS";
    private int coins
    {
        get
        {
            return PlayerPrefs.GetInt(saveName, 0);
        }
        set
        {
            PlayerPrefs.SetInt(saveName, value);
            PlayerPrefs.Save();
        }
    }

    public CoinsService()
    {
        GlobalEvents.AddCoins.AddListener(AddCoins);
        GlobalEvents.SpendCoins.AddListener(TrySpendCoins);
    }

    private void AddCoins(int value)
    {
        coins += value;
        GlobalEvents.UpdateCoins.Invoke(coins);
    }

    private void TrySpendCoins(int value)
    {
        if (SpendCoins(value) == true)
        {
            GlobalEvents.SpendCoinsSucces.Invoke(value);
            return;
        }
        GlobalEvents.SpendCoinsError.Invoke(value);
    }

    private bool SpendCoins(int value)
    {
        if (coins - value >= 0)
        {
            coins -= value;
            GlobalEvents.UpdateCoins.Invoke(coins);
            return true;
        }
        return false;
    }

    public int GetCoins => coins;
}
