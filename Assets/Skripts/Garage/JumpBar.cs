using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;
public class JumpBar : MonoBehaviour
{
    public Slider jumpPowerBar;
    public Image fillAmountOfJumpPower;
    private int UpgradeJumpPowerPrice;
    public Button jumpPowerUpgrade;
    public  TextMeshProUGUI ButtonText;
    // Start is called before the first frame update
    void Start()
    {
        UpgradeJumpPowerPrice = 6000;
        jumpPowerBar.value = 0.3f;
        Player.Instance.Inventory.coinAmountChanged += UpdateTextColor;
        ButtonText.text = $"{UpgradeJumpPowerPrice}";
    }

    public void JumpPowerUpgrade()
    {
        if(Player.Instance.Inventory.CoinAmount >=  UpgradeJumpPowerPrice)
        {
            Player.Instance.PlayerMovement.UpgradeJumpSpeed();
            Player.Instance.Inventory.RemoveCoins(UpgradeJumpPowerPrice);
            UpdateJumpPowerSlider();
        }
    }

    public void UpdateJumpPowerSlider()
    {
        jumpPowerBar.value += 0.1f;
        UpgradeJumpPowerPrice += 4000;
        UpdateTextColor();
    }

    private void UpdateTextColor()
    {
        if (Player.Instance.Inventory.CoinAmount < UpgradeJumpPowerPrice)
        {
            ButtonText.color = Color.red;
        }
        ButtonText.text = $"{UpgradeJumpPowerPrice}";
    }
}
