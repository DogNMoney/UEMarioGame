using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for handling enemy life/death on collisions etc
//it is moved to separate script to not be dependent on movement
public class EnemyLife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
            Destroy(GameObject.FindWithTag("Bullet"));
        }
    }
}
