using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_score : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        { CoinManager.instance.ChangeScore();
            
        }
    }
}
