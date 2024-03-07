using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikes : MonoBehaviour
{
   [SerializeField]private float fallDelay;
   [SerializeField]private float destroyDelay;

    [SerializeField] private Rigidbody2D rb;
    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;

        PlayerDeath playerdeath = FindObjectOfType<PlayerDeath>();
        playerdeath.playerdied += ResetObjectsForTrap;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Falls");
            StartCoroutine(Fall());
        }     
    }
    private void ResetObjectsForTrap() 
    {
        gameObject.transform.position = startPos;
        rb.bodyType = RigidbodyType2D.Kinematic;
        gameObject.SetActive(true);

        if (Fall() != null)
            StopCoroutine(Fall());
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
