using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 1f;
    private Rigidbody2D player;
    private BoxCollider2D collider2d;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        handleHorizontalMovement();
        handleVerticalMovement();
    }

    private void handleVerticalMovement()
    {
        if(Input.GetKey(KeyCode.W) && isGrounded())
        {
            player.AddForce(new Vector3(0f, 350f * jumpPower));
           
        }
    }

    private bool isGrounded()
    {
        return player.velocity.y > -0.01f && player.velocity.y < 0.01f;
    }

    private void handleHorizontalMovement()
    {
        Vector3 force = new Vector3(0f, 0f, 0f);
        if (Input.GetKey(KeyCode.A))
        {
            force.x -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            force.x += speed;
        }

        force *= Time.deltaTime;
        player.transform.Translate(force);
    }
}
