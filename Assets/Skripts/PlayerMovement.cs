using Cainos.PixelArtPlatformer_VillageProps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
   
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float wallSlidingSpeed;
    private bool canDoubleJump = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        canDoubleJump = true;
    }
    public void Move(float xDir) 
    {
        if(xDir != 0)
        {

           rb.velocity = new Vector2(xDir * speed, rb.velocity.y);
        }
        else if (xDir == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
    }
    public void WallSlide()
    {
        rb.velocity = new Vector2(0, -wallSlidingSpeed);
    }
    public void WallJump()
    {
        Jump();    
    }
    public void TryToDoubleJump()
    {
        if (canDoubleJump)
        {
            Jump();

            canDoubleJump = false;
        }     
    }
    public void ResetDoubleJump() => canDoubleJump = true;
}
