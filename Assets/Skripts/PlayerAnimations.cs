using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private NewPlayer np;
    private Animator anim;
    public SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        np = GetComponent<NewPlayer>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(np.State)
        {
            case NewPlayer.MovementState.Idle:
                anim.Play("Idle");
                break;
            case NewPlayer.MovementState.Running:
                anim.Play("Run");
                break;
            case NewPlayer.MovementState.Falling:
                anim.Play("Fall");
                break;
            case  NewPlayer.MovementState.Jumping:
                anim.Play("Jump");
                    break;
            case NewPlayer.MovementState.WallSliding:
                anim.Play("WallSlide");
                break;

        }
        spr.flipX = np.IsFacingRight ? false :true;
    }
}
