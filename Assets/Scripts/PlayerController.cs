using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float thrust = 10.0f;
    public LayerMask groundLayerMask;
    public Animator animator;
    public float runSpeed = 3.0f;
    private static PlayerController sharedInstance;

    private Vector3 initialPosition;
    private Vector2 initialVelocity;

    private void Awake()
    {
        sharedInstance = this;
        rigidBody = GetComponent<Rigidbody2D>();

        initialPosition = transform.position;
        initialVelocity = rigidBody.velocity;
        animator.SetBool("isAlive", true);
    }
    public static PlayerController GetInstance()
    {
        return sharedInstance;
    }
    // Start is called before the first frame update
   public void StartGame()
    {
      
        animator.SetBool("isAlive", true);
        transform.position = initialPosition;
        rigidBody.velocity = new Vector2(0,0);
        
    }
    private void FixedUpdate()
    {
        GameState currState = GameManager.GetInstance().currentGameState;
        if (currState == GameState.InGame)
        {
            if (rigidBody.velocity.x < runSpeed)
            {
                rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
       bool canJump  = GameManager.GetInstance().currentGameState == GameState.InGame;
        bool isOnTheGround = IsOnTheGround();
        animator.SetBool("isGrounded", isOnTheGround);
        if (canJump && (Input.GetMouseButtonDown(0)

            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.W)
            ) && isOnTheGround
            )
        {
            Jump();
        }

    }
    void Jump()
    {
       
            rigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
        
        
    }
    bool IsOnTheGround()
    {
       
     return Physics2D.Raycast(this.transform.position, Vector2.down,
            1.0f, groundLayerMask.value) ;
       
    }

    public void KillPlayer()
    {
        animator.SetBool("isAlive", false);
        GameManager.GetInstance().GameOver();

    }
}
