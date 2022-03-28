using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            //jump
            rb2d.velocity = new Vector2(rb2d.velocity.x, 10);
        }

        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(2, rb2d.velocity.y);
        }

        if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-2, rb2d.velocity.y);
        }
    }
}
