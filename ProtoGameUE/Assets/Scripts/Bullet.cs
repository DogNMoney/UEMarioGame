using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f;
    private float currentSpeed= 0f;
    private Rigidbody2D bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpeed != 0f)
        {
            bullet.transform.Translate(new Vector3(currentSpeed, 0f));
        }
    }

    public void shoot(bool shootRight)
    {
        currentSpeed = shootRight ? speed : -speed;
    }
}
