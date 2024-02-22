using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private Button UpgradeButton;

    public static PlayerMovement playerMovement { get; private set; }
    public static EndLogic endlogic { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0.1f;
        playerMovement = FindObjectOfType<PlayerMovement>();
        endlogic = FindObjectOfType<EndLogic>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HasUpgraded()
    {
        if (playerMovement != null && endlogic.coinAmount >= 5000)
        {
            slider.value += 0.1f;
            playerMovement.speed += 10f;
            endlogic.coinAmount -= 5000;
        }
        else
        {
            Debug.Log("Not enough Coins!");
        }
    }

    public void SetSliderV()
    {

    }
}
