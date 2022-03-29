using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Rigidbody2D rb2d;

    bool isGrounded;
    public float jumpForce;
    public float jumpTime;
    bool isJumping;
    float jumpTimeCounter;

    //move state
    public float moveSpeed;
    float moveInput;

    
    [SerializeField]
    Transform groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")) && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKeyUp("space") || Input.GetKeyUp("w"))
        {
            isJumping = false;
        }

        moveInput = Input.GetAxisRaw("Horizontal");
        
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb2d.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
                Debug.Log(jumpTimeCounter);
            }
            else
            {
                isJumping = false;
            }
        }

        rb2d.velocity = new Vector2(moveInput * moveSpeed, rb2d.velocity.y);
    }
}
