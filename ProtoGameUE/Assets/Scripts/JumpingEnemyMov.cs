using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyMov : MonoBehaviour
{
    public float jumpingHorizontalRange = 1f;
    public float jumpVerticalForce = 1f;
    private float horizontalForce;
    private Rigidbody2D enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        horizontalForce = jumpingHorizontalRange;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Utils.isGrounded(enemy))
        {
            horizontalForce = -horizontalForce;
            enemy.AddForce(new Vector2(0f, Utils.DEFAULT_JUMP_HEIGHT * jumpVerticalForce));
        }
        enemy.transform.Translate(new Vector3(horizontalForce * Time.deltaTime, 0f, 0f));
    }
}
