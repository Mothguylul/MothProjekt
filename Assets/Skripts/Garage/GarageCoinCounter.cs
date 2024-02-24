using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GarageCoinCounter : MonoBehaviour
{
    private TextMeshProUGUI coinAmountOfPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        coinAmountOfPlayer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoins();
    }

    public void UpdateCoins()
    {
        coinAmountOfPlayer.text = NewPlayer.Instance.Inventory.CoinAmount.ToString();
    }
}
