using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Player np;
    private Animator anim;
    public SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        np = GetComponent<Player>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(np.State)
        {
            case Player.MovementState.Idle:
                anim.Play("Idle");
                break;
            case Player.MovementState.Running:
                anim.Play("Run");
                break;
            case Player.MovementState.Falling:
                anim.Play("Fall");
                break;
            case  Player.MovementState.Jumping:
                anim.Play("Jump");
                    break;
            case Player.MovementState.WallSliding:
                anim.Play("WallSlide");
                break;

        }
        spr.flipX = np.IsFacingRight ? false :true;
    }
}
