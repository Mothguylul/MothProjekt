using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInventory 
{
    private int coinAmount;
    public int CoinAmount => coinAmount;
    public event Action coinAmountChanged;

    
    public void AddCoins(int amount)
    {
        coinAmount += amount + 30000;
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
