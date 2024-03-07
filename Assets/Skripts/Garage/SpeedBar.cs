using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;

public class SpeedBar : MonoBehaviour
{
    // public TextMeshProUGUI coinAmountofPlayer;
    public event Action speedBarIncreased;
    public Button UpgradeButtonForSpeed;
    public Slider SpeedBarSlider;
    public Image fillAmount;
    private int UpgradeSpeedPrice;
    public TextMeshProUGUI ButtonText;

    // Start is called before the first frame update
    void Start()
    {
        speedBarIncreased += UpdateSliderValue;
        UpgradeSpeedPrice = 6000;
        SpeedBarSlider.value = 0.1f;
        fillAmount.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonText.text = $"{UpgradeSpeedPrice}";
        if (Player.Instance.Inventory.CoinAmount < UpgradeSpeedPrice)
        {
            ButtonText.color = Color.red;
        }
    }

    void colorChanger()
    {
        Color speedColor = Color.Lerp(Color.yellow, Color.green, SpeedBarSlider.minValue / SpeedBarSlider.maxValue);
        fillAmount.color = speedColor;
    }

    public void SpeedUpgraded()
    {
        if (Player.Instance.Inventory.CoinAmount >= UpgradeSpeedPrice)
        {
            Player.Instance.PlayerMovement.UpgradeSpeed();
            colorChanger();
            Player.Instance.Inventory.RemoveCoins(UpgradeSpeedPrice);
            speedBarIncreased?.Invoke();
            Debug.Log("Has Upgraded speed");
        }
        else
        {
           
            Debug.Log("Not enough Coins!");
        }
    }
    public void UpdateSliderValue()
    {
        SpeedBarSlider.value += 0.1f;
        UpgradeSpeedPrice += 3000;
    }
}
