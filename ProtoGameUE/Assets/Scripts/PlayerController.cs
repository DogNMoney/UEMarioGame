using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 1f;
    public long shootDelay = 120;
    public KeyCode jump;
    public KeyCode left;
    public KeyCode right;
    public KeyCode shoot;
    public GameObject currentBullet;
    public int fAmmo;
    public int fHp;
    private bool isRight = true;
    private Rigidbody2D player;
    private BoxCollider2D collider2d;
    private const float AIR_SPEED_MULTIPLIER = 0.75f;
    private long lastShoot = 0;
    private Animator animator;
    private Vector3 force = new Vector3(0f, 0f, 0f);
    Transform playerTrans;
    Vector3 currRot;
    bool direction ;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
        playerTrans = this.transform;
        globalVar.Ammo = fAmmo;
        globalVar.Hp = fHp;
        animator = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
  
        handleHorizontalMovement();
        handleVerticalMovement();
        handleShooting();

        animator.SetBool("isMoving", force.x != 0 );
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision with " + collision.gameObject.tag);
        if(collision.gameObject.tag == "Enemy")
        {
            die();
        }
        
    }

    private void die()
    {
        globalVar.Hp--;
        Destroy(gameObject);
        
    }

    private void handleShooting()
    {
        long diff = DateTimeOffset.Now.ToUnixTimeMilliseconds() - lastShoot;
        //Debug.Log("Diff " + diff + " > " + shootDelay);
        if (Input.GetKey(shoot) && diff > shootDelay && globalVar.Ammo >0)
        {
            globalVar.Ammo--;
            lastShoot = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            GameObject bullet = Instantiate(currentBullet, player.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().shoot(isRight);
            Debug.Log(globalVar.Ammo);
        }
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
        
      
        if (Input.GetKey(left))
        {
            Vector3 currRot = playerTrans.eulerAngles;
            currRot.y = 180;
            playerTrans.eulerAngles = currRot;

            isRight = false;
            force.x += speed;
           

        }
        if (Input.GetKey(right))
        {
            Vector3 currRot = playerTrans.eulerAngles;
            currRot.y = 0;
            playerTrans.eulerAngles = currRot;
            isRight = true;
            force.x += speed;
           
        }
        if (!Utils.isGrounded(player))
        {
            force *= AIR_SPEED_MULTIPLIER;
        }
        force *= Time.deltaTime;
        player.transform.Translate(force);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
          if (collision.gameObject.tag == "Ammo")
            {
             handleAmmoPickup();
            Destroy(collision.gameObject);
            }
    }
    private void  handleAmmoPickup()
    {
        globalVar.Ammo += 3;
    }
   
}
