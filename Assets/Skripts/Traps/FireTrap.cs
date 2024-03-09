using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class FireTrap : MonoBehaviour
{
    private bool active;
    private bool playerIsClose;
    private Animator animator;
    private PlayerDeath playerDeath;
    void Start()
    {
        playerDeath = Game.Player.GetComponent<PlayerDeath>();
        animator = GetComponent<Animator>();
        StartCoroutine(SetState());
    }

    void Update()
    {
        if (playerIsClose && active)
        {
            playerDeath.StartCoroutine(playerDeath.Dieco());
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
            animator.Play("on");
            yield return new WaitForSeconds(1);
            animator.Play("Idle");
            active = false;
        }
    }
}
