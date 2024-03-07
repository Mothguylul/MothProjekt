using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GarageCoinCounter : MonoBehaviour
{
    private TextMeshProUGUI coinAmountOfPlayer;
    
    void Awake()
    {
        coinAmountOfPlayer = GetComponent<TextMeshProUGUI>();
        UpdateCoins();
        Game.Inventory.coinAmountChanged += UpdateCoins;
    }

    public void UpdateCoins()
    {
        coinAmountOfPlayer.text = Player.Instance.Inventory.CoinAmount.ToString();
    }
}
