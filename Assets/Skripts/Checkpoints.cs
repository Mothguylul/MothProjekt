using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Checkpoints : MonoBehaviour
{
    public ParticleSystem explosionCheckPoints;
    private bool hasPlayedExplosion = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerDeath playerDeath = collision.gameObject.GetComponent<PlayerDeath>();
            playerDeath.UpdateCheckPoint(transform.position);
            if (!hasPlayedExplosion)
            {
                explosionCheckPoints.Play();
                hasPlayedExplosion = true;
            }
            else if (hasPlayedExplosion)
                return;
        }
    }
}
