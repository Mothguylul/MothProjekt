using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public ParticleSystem dust;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private float wallSlidingSpeed;

    public bool IsFacingRight { get; private set; } = true;
    public PlayerInventory Inventory {  get; private set; }
    public static NewPlayer Instance { get; private set; }

    public PlayerMovement playermovement;

    public enum MovementState
    {
        Idle,
        Running,
        Jumping,
        WallSliding,
        Falling,
    }

    private MovementState state;
    public MovementState State => state;
    
    private void Awake()
    {
        playermovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        Inventory = new PlayerInventory();

        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
       state = MovementState.Idle;     
       
    }

    private void Update()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        bool pressedJump = Input.GetKeyDown(KeyCode.Space);
        state = SetState(xDir);
        HandleInput(xDir, pressedJump);

        if(xDir < 0)
        {
            IsFacingRight = false;      
        }
        else if (xDir > 0) 
        {
            IsFacingRight = true;        
        }
    }
    private MovementState SetState(float xDir)
    {
        if (IsOnGround())
        {
            playermovement.ResetDoubleJump();
            return (xDir == 0) ? MovementState.Idle : MovementState.Running;
        }     

        if (IsOnWall(xDir))
        {
            playermovement.ResetDoubleJump();
            Debug.Log("Wall Detected!");
            return MovementState.WallSliding;
        }

        return (rb.velocity.y > 0) ? MovementState.Jumping : MovementState.Falling;
    }

    private bool IsOnGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckRadius, whatIsGround);
    }

    private bool IsOnWall(float xDir)
    {
        
        if (xDir == 0)
            return false;

        if (rb.velocity.y > 0)
            return false;

        return Physics2D.Raycast(transform.position, xDir > 0 ? Vector2.right : Vector2.left, wallCheckDistance, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckRadius);
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + wallCheckDistance, transform.position.y, transform.position.z));
    }

    private void HandleInput(float xDir, bool pressedJump)
    {
        switch(state)
        {
            // if we're idle or running we're on the ground, so we can do both
            case MovementState.Idle:
                if(xDir == 0 && rb.velocity.y == 0)
                {
                   rb.velocity = new Vector2(0, 0);
                    dust.Stop();
                }
                if (pressedJump)
                    playermovement.Jump();
                break;
            case MovementState.Running:
                if (xDir != 0)
                {
                    playermovement.Move(xDir);
                    dust.Play();
                }
                if (pressedJump)
                    playermovement.Jump();
                break;

            // if we're jumping or falling we can't jump anymore (at least for now), but we can still move
            case MovementState.Jumping:
            case MovementState.Falling:
                if (xDir != 0)
                    playermovement.Move(xDir);
                else if (xDir == 0)
                    rb.velocity = new Vector2(0, rb.velocity.y);
                if (pressedJump)
                    playermovement.TryToDoubleJump();
                break;

            // if we're on a wall we can only wall slide or wall jump
            case MovementState.WallSliding:
                playermovement.WallSlide();
                if (pressedJump)
                    playermovement.WallJump();
                break;

        }
    }

}

