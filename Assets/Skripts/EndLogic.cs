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
    public int coinAmount;
   
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
        NewPlayer.Instance.Inventory.AddCoins(CalculateCoins());
        coinEndText.text = $"{coinAmount}";
        CoinCounter.text = "";
        CoinCounter.text += $"{coinAmount}";      
    }
    public int CalculateCoins()
    {
        if (dc.CurrentdeathCount <= 5)
            return Random.Range(9000, 10000);
        else if (dc.CurrentdeathCount <= 10)
            return Random.Range(7000, 8000);
        else if (dc.CurrentdeathCount <= 20)
            return Random.Range(4000, 6000);
        else if (dc.CurrentdeathCount <= 35)
            return Random.Range(2000, 4000);
        else if (dc.CurrentdeathCount <= 50)
            return Random.Range(1, 2000);
       
            return Random.Range(1, 5);
    }
}

