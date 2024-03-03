using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class FireTrap : MonoBehaviour
{
    private SpriteRenderer spr;
    private bool active;
    private bool playerIsClose;
    public Animator anim;

    public PlayerDeath pd { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        pd = Game.Player.GetComponent<PlayerDeath>();
        StartCoroutine(SetState());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsClose && active)
        {
            pd.StartCoroutine(pd.Dieco());
            playerIsClose = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")      
            playerIsClose = true;
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            playerIsClose = false;

    }

    private IEnumerator SetState()
    {
        while (true)
        {
            yield return new WaitForSeconds((float)1.8);
            active = true;
            anim.Play("on");
            Debug.Log("active true");
            yield return new WaitForSeconds(1);
            anim.Play("Idle");
            Debug.Log("Active and triggerd false");
            active = false;
        }
    }
}
