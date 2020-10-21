using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float thrust = 10.0f;
    public LayerMask groundLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)

            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.W)
            )
        {
            Jump();
        }

    }
    void Jump()
    {
        if (IsOnTheGround())
        {
            rigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
        }
        
    }
    bool IsOnTheGround()
    {
        print("mask=" + groundLayerMask);
     return Physics2D.Raycast(this.transform.position, Vector2.down,
            1.0f, groundLayerMask.value) ;
       
    }
}
