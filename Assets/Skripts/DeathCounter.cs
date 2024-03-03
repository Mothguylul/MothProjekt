using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    public TextMeshProUGUI deathcount;
    private PlayerDeath pd;
    private int currentDeathCount;
    public int CurrentdeathCount => currentDeathCount;
    
    // Start is called before the first frame update
    void Start()
    {
        currentDeathCount = 0;     
        deathcount.text = $"{currentDeathCount}";
        PlayerDeath playerdeath = FindObjectOfType<PlayerDeath>();
        playerdeath.playerdied += UpdateDeathCount;
    }   
    private void UpdateDeathCount()
    {
        currentDeathCount++;
        deathcount.text = "" + currentDeathCount;
        Debug.Log("has Deathcount updated");

    }
}
