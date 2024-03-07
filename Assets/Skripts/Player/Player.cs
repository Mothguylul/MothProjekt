using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private Rigidbody2D rigidBody;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float wallCheckDistance;
    public bool IsFacingRight { get; private set; } = true;
    public PlayerInventory Inventory {  get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }

    public enum MovementState
    {
        Idle,
        Running,
        Jumping,
        WallSliding,
        Falling,
    }

    private MovementState state = MovementState.Idle;
    public MovementState State => state;
    
    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        rigidBody = GetComponent<Rigidbody2D>();
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
            PlayerMovement.ResetDoubleJump();
            return (xDir == 0) ? MovementState.Idle : MovementState.Running;
        }     

        if (IsOnWall(xDir))
        {
            PlayerMovement.ResetDoubleJump();
            return MovementState.WallSliding;
        }

        return (rigidBody.velocity.y > 0) ? MovementState.Jumping : MovementState.Falling;
    }

    private bool IsOnGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckRadius, whatIsGround);
    }

    private bool IsOnWall(float xDir)
    {
        
        if (xDir == 0)
            return false;

        if (rigidBody.velocity.y > 0)
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
                if(xDir == 0 && rigidBody.velocity.y == 0)
                {
                   rigidBody.velocity = new Vector2(0, 0);
                    
                }
                if (pressedJump)
                    PlayerMovement.Jump();
                break;
            case MovementState.Running:
                if (xDir != 0)
                {
                    PlayerMovement.Move(xDir);
                    
                }
                if (pressedJump)
                    PlayerMovement.Jump();
                break;

            // if we're jumping or falling we can't jump anymore (at least for now), but we can still move
            case MovementState.Jumping:
            case MovementState.Falling:
                if (xDir != 0)
                    PlayerMovement.Move(xDir);
                else if (xDir == 0)
                    rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
                if (pressedJump)
                    PlayerMovement.TryToDoubleJump();
                break;

            // if we're on a wall we can only wall slide or wall jump
            case MovementState.WallSliding:
                PlayerMovement.WallSlide();
                if (pressedJump)
                    PlayerMovement.WallJump();
                break;

        }
    }
}

