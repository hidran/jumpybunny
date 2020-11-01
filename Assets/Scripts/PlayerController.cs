using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float thrust = 15.0f;
    public LayerMask groundLayerMask;
    public Animator animator;
    public float runSpeed = 5.0f;
    private static PlayerController sharedInstance;

    private Vector3 initialPosition;
    private Vector2 initialVelocity;
    private float initialGravity;
    private const string HIGHEST_SCORE_KEY = "highestScore";
    private void Awake()
    {
       
        sharedInstance = this;
        rigidBody = GetComponent<Rigidbody2D>();
      
        initialPosition = transform.position;
        initialVelocity = rigidBody.velocity;
        animator.SetBool("isAlive", true);
        initialGravity = rigidBody.gravityScale;
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
        rigidBody.velocity = initialVelocity;
        rigidBody.gravityScale = initialGravity;

        
        
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
       
        int highestScore = PlayerPrefs.GetInt(HIGHEST_SCORE_KEY);
        int currentScore = GetDistance();
        if(currentScore > highestScore)
        {
            PlayerPrefs.SetInt(HIGHEST_SCORE_KEY, currentScore);
        }
        rigidBody.gravityScale = 0f;
        rigidBody.velocity = Vector2.zero;
        GameManager.GetInstance().GameOver();
       
    }

    public int GetDistance()
    {
        var distance = (int) Vector2.Distance(initialPosition,
                transform.position
            );
        print("distance =" + distance);
        return distance;
    }
    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt(HIGHEST_SCORE_KEY);
    }
}
