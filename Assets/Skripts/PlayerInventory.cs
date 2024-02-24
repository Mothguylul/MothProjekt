using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory 
{
    private int coinAmount;
    public int CoinAmount => coinAmount;

    public void AddCoins(int amount)
    {
        coinAmount += amount;
    }
}
