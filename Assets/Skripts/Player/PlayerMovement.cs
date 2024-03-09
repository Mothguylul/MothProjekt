using Cainos.PixelArtPlatformer_VillageProps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField] private float jumpSpeed, speed, wallSlidingSpeed;
    private const float MAX_SPEED = 10f, MIN_SPEED = 6f, MIN_JUMPSPEED = 9f, MAX_JUMPSPEED = 13f;
    public bool canDoubleJump = false;
    [Header("De/Acceleration")]
    [SerializeField] private float acceleration, decceleration;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();   
    }
    public void Jump()
    {
       rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);     
       canDoubleJump = true;      
    }

    public void Move(float xDir) 
    {
        if (xDir != 0)
        {
            rigidBody.velocity = new Vector2(xDir * speed, rigidBody.velocity.y);
        }
        else if (xDir == 0)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y);
        }
        
        /*if (xDir != 0)
        {
            float targetSpeed = xDir * speed;
            float speedDifference = targetSpeed - rigidBody.velocity.x;
            float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
            float accelerationAmount = Mathf.Sign(speedDifference) * accelRate * Time.deltaTime;

            float newVelocityX = rigidBody.velocity.x + accelerationAmount;
            rigidBody.velocity = new Vector2(newVelocityX, rigidBody.velocity.y);
        }
        else if (xDir == 0)
        {
            float decelerationAmount = Mathf.Sign(rigidBody.velocity.x) * decceleration * Time.deltaTime;
            float newVelocityX = rigidBody.velocity.x - decelerationAmount;

            newVelocityX = Mathf.Clamp(newVelocityX, 0f, Mathf.Infinity);
            rigidBody.velocity = new Vector2(newVelocityX, rigidBody.velocity.y);
        }*/

    }

    public void WallSlide()
    {
        rigidBody.velocity = new Vector2(0, -wallSlidingSpeed);
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

    public void UpgradeSpeed()
    {
        speed += Mathf.Clamp(speed + 1, MIN_SPEED, MAX_SPEED);
    }

    public void UpgradeJumpSpeed()
    {
        jumpSpeed += Mathf.Clamp(jumpSpeed + .8f, MIN_JUMPSPEED, MAX_JUMPSPEED);
    }

    public void ResetDoubleJump() => canDoubleJump = true;
}
