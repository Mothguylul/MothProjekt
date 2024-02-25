using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;
    public Transform startpos;
    public event Action playerdied;
    public ParticleSystem dustPS;
    public bool playerDied;


    private void Start()
    {

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();  
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            StartCoroutine(Dieco());
        }
    }
    public IEnumerator Dieco()
    {   
        playerDied = true;
        if (playerDied)
        {
          GetComponent<NewPlayer>().enabled = false;
          GetComponent<PlayerAnimations>().enabled = false;
       
          rigid.bodyType = RigidbodyType2D.Static;
          dustPS.Stop();
          anim.Play("Die");

          yield return new WaitForSeconds(1);
          RestartLevel1();
          yield return new WaitForSeconds(.2f);
          SetBodyType();
          SetSkriptsback();

          playerdied?.Invoke();

        }
        playerDied = false;

    }

    private void SetBodyType()
    {
        rigid.bodyType = RigidbodyType2D.Dynamic;
        dustPS.Play();
    }

    public void UpdateCheckPoint(Vector2 position)
    {
        startpos.transform.position = position;
    }

    private void SetSkriptsback()
    {
        GetComponent<NewPlayer>().enabled = true;
        GetComponent<PlayerAnimations>().enabled = true;
    }
   
    public void RestartLevel1()
    {
        transform.position = startpos.transform.position;
    }
}
