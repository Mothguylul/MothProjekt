using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float bounce;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.Play("Tramploin_Jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Invoke(nameof(CallTrampolinIdle), 0.7f);
    }

    private void CallTrampolinIdle()
    {
        anim.Play("Trampolin_Idle");
        Debug.Log("Trys to Idle Animation");
    }
}
