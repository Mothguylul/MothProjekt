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
    private int UpgradeSpeedPrice;


    // Start is called before the first frame update
    void Start()
    {
        speedBarIncreased += UpdateSliderValue;
        UpgradeSpeedPrice = 6000;
        SpeedBarSlider.value = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpeedUpgraded()
    {
        if(NewPlayer.Instance.Inventory.CoinAmount > UpgradeSpeedPrice)
        {
          NewPlayer.Instance.playermovement.speed += 10f;
          NewPlayer.Instance.Inventory.RemoveCoins(UpgradeSpeedPrice);
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
        UpgradeSpeedPrice += 4000;
    }
}
