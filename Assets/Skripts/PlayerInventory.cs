using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory 
{
    private int coinAmount;
    public int CoinAmount => coinAmount;
    public event Action coinAmountChanged;

    public void AddCoins(int amount)
    {
        coinAmount += amount;
        coinAmountChanged?.Invoke();
    }

    public void RemoveCoins(int amount)
    {
        coinAmount -= amount;

        if (coinAmount <= 0)
            coinAmount = 0;

        coinAmountChanged?.Invoke();

    }
}
