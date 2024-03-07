using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class EndLogic : MonoBehaviour
{
    public GameObject Endpanel;
    public ParticleSystem EndpanelParticle;
    public DeathCounter dc;
    public TextMeshProUGUI coinEndText;
    public TextMeshProUGUI CoinCounter;
    public event Action HasEndedLevel1; 
   
    // Start is called before the first frame update
    void Start()
    {
        dc = FindObjectOfType<DeathCounter>();
        CoinCounter.text = "" + 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EndpanelParticle.Play();
        StartCoroutine(SetPanelCo());
    }
    private IEnumerator SetPanelCo()
    {
        yield return new WaitForSeconds(0.8f);
        Endpanel.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        if (Endpanel.activeInHierarchy)
            Time.timeScale = 0;
        int coinAmount = CalculateCoins();
        Game.Inventory.AddCoins(coinAmount);
        coinEndText.text = $"{coinAmount}";
        CoinCounter.text = $"{Game.Inventory.CoinAmount}";
        HasEndedLevel1?.Invoke();
    }
    public int CalculateCoins()
    {
        if (dc.CurrentdeathCount <= 5)
            return  UnityEngine.Random.Range(9000, 10000);
        else if (dc.CurrentdeathCount <= 10)
            return UnityEngine.Random.Range(7000, 8000);
        else if (dc.CurrentdeathCount <= 20)
            return UnityEngine.Random.Range(4000, 6000);
        else if (dc.CurrentdeathCount <= 35)
            return UnityEngine.Random.Range(2000, 4000);
        else if (dc.CurrentdeathCount <= 50)
            return UnityEngine.Random.Range(1, 2000);
       
            return UnityEngine.Random.Range(1, 5);
    }
}

