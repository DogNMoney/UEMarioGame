using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    public LayerMask enemyMask;
    public float speed = 1;
     Rigidbody2D enemyBody;
     Transform enemyTrans;
     float enemyWidth;

    // Start is called before the first frame update
    void Start()
    {
        enemyTrans = this.transform;
        enemyBody = this.GetComponent<Rigidbody2D>();
        enemyWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lineCastPos = enemyTrans.position - enemyTrans.right * enemyWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down , Color.white);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        if (!isGrounded)
        {
            Vector3 currRot = enemyTrans.eulerAngles;
            currRot.y += 180;
            enemyTrans.eulerAngles = currRot;
        }
       // Debug.Log(isGrounded);
        Vector2 enemyVel = enemyBody.velocity;
        enemyVel.x = -enemyTrans.right.x * speed;
        enemyBody.velocity = enemyVel;

    }
    
}

