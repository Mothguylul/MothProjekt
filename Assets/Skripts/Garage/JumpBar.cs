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
    public event Action jumpBarChanged;
    public Slider jumpPowerBar;
    public Image fillAmountOfJumpPower;
    private int UpgradeJumpPowerPrice = 6000;
    public Button jumpPowerUpgrade;
    public  TextMeshProUGUI ButtonText;
    // Start is called before the first frame update
    void Start()
    {
        jumpBarChanged += UpdateJumpPowerSlider;
        jumpPowerBar.value = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonText.text = $"{UpgradeJumpPowerPrice}";
        if(Player.Instance.Inventory.CoinAmount < UpgradeJumpPowerPrice)
        {
            ButtonText.color = Color.red;
        }
    }

    public void JumpPowerUpgrade()
    {
        if(Player.Instance.Inventory.CoinAmount >=  UpgradeJumpPowerPrice)
        {
            Player.Instance.PlayerMovement.UpgradeJumpSpeed();
            Player.Instance.Inventory.RemoveCoins(UpgradeJumpPowerPrice);
            jumpBarChanged?.Invoke();
            Debug.Log("Has Jump Increased");
        }
        else
        {
            Debug.Log("Not enough Coins");
        }
    }

    public void UpdateJumpPowerSlider()
    {
        jumpPowerBar.value += 0.1f;
        UpgradeJumpPowerPrice += 4000;

    }
}
