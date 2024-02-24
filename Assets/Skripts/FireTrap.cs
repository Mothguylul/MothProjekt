using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private SpriteRenderer spr;
    private bool active;

    public PlayerDeath pd {  get; set; }
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SetState());
           

        }
    }

    private IEnumerator SetState()
    {
        spr.color = Color.red;
        yield return new WaitForSeconds(1);
        spr.color = Color.white;
        active = true;
        Debug.Log("Settet Coroutine");


    }
}
