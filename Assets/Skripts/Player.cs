using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed = 6;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform WallCheck;
    [SerializeField] private float WallCheckDistance;
    [SerializeField] private float WallSlidingSpeed = 6f;
    [SerializeField] private Vector2 WallJumpDirection;

    private bool isfacingRight = true;
    private float movingInput;
    private int facingDirection = 1;
    private bool canWalljump = true;
    private bool canMove = true;
    private bool IsWallDetected;
    private bool canWallSLide;
    private bool IsWallSliding;
    private bool isGrounded;
    private bool canDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isGrounded)
        {
            canMove = true;
            canDoubleJump = true;
        }

        if (IsWallDetected && canWallSLide)
        {

            IsWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * WallSlidingSpeed);
        }
        else if (!IsWallDetected)
        {
            IsWallSliding = false;
            Move();
        }

        if (IsWallDetected && movingInput == 0)
        {
            canMove = false;
            IsWallSliding = false;


            Vector3 moveDirection = isfacingRight ? Vector3.right : Vector3.left;

            Vector3 targetPosition = transform.position + moveDirection * 0.5f;

            float moveSpeed = 25f; // Geschwindigkeit der Bewegung


            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            canMove = true;

        }

        CheckInput();
        CollisionCheck();
        FlipController();
        AnimatorController();
    }
    private void FixedUpdate()
    {

    }

    private void WallJump()
    {

        Vector2 direction = new Vector2(WallJumpDirection.x * -facingDirection, WallJumpDirection.y);

        rb.AddForce(direction, ForceMode2D.Impulse);
    }

    private void Move()
    {
        if (canMove)
        {

            rb.velocity = new Vector2(movingInput * speed, rb.velocity.y);

        }
    }

    private void CheckInput()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpButton();
        }
        if (canMove)
        {

            movingInput = Input.GetAxisRaw("Horizontal");
        }
    }

    private void Flip()
    {
        facingDirection = facingDirection * -1;
        isfacingRight = !isfacingRight;

        transform.Rotate(0, 180, 0);
    }

    private void FlipController()
    {
        if (isGrounded && IsWallDetected)
        {
            if (isfacingRight && movingInput < 0)
            {
                Flip();
            }
            else if (!isfacingRight && movingInput > 0)
            {
                Flip();
            }
        }

        if (rb.velocity.x > 0 && !isfacingRight)
        {
            Flip();
        }
        else if (rb.velocity.x < 0 && isfacingRight)
        {
            Flip();
        }
    }

    private void JumpButton()
    {
        if (IsWallSliding && canWalljump)
        {
            WallJump();
        }

        else if (isGrounded)
        {
            Jump();
        }
        else if (canDoubleJump)
        {
            canMove = true;
            canDoubleJump = false;
            Jump();
        }

        canWallSLide = false;
    }

    private void Jump()
    {

        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }

    private void AnimatorController()
    {
        bool isMoving = rb.velocity.x != 0;

        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isWallsliding", IsWallSliding);
    }

    private void CollisionCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        IsWallDetected = Physics2D.Raycast(WallCheck.position, Vector2.right, WallCheckDistance, whatIsGround);

        if (!isGrounded && rb.velocity.y < 0)
        {
            canWallSLide = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        Gizmos.DrawLine(WallCheck.position, new Vector3(WallCheck.position.x + WallCheckDistance, WallCheck.position.y, WallCheck.position.z));
    }
}
