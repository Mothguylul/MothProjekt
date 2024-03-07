using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Checkpoints : MonoBehaviour
{
    private ParticleSystem explosionCheckPoints;
    private bool hasPlayedExplosion = false;

    private void Awake()
    {
        explosionCheckPoints = GetComponentInChildren<ParticleSystem>();
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
        }
    }
}
