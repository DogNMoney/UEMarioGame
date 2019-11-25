using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 1f;
    public KeyCode jump;
    public KeyCode left;
    public KeyCode right;

    private Rigidbody2D player;
    private BoxCollider2D collider2d;
    private const float AIR_SPEED_MULTIPLIER = 0.75f;
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
        if(Input.GetKey(jump) && Utils.isGrounded(player))
        {
            player.AddForce(new Vector3(0f, Utils.DEFAULT_JUMP_HEIGHT * jumpPower));
        }
    }

    private void handleHorizontalMovement()
    {
        Vector3 force = new Vector3(0f, 0f, 0f);
        if (Input.GetKey(left))
        {
            force.x -= speed;
        }
        if (Input.GetKey(right))
        {
            force.x += speed;
        }
        if (!Utils.isGrounded(player))
        {
            force *= AIR_SPEED_MULTIPLIER;
        }
        force *= Time.deltaTime;
        player.transform.Translate(force);
    }
}
