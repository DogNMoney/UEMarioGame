using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelData : MonoBehaviour
{
    private Text life;
    private Text coins;
    private Text bullets;
    // Start is called before the first frame update
    void Start()
    {
        life = transform.Find("Lifes").GetComponent<Text>();
        coins = transform.Find("Coins").GetComponent<Text>();
        bullets = transform.Find("bullets").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        life.text = globalVar.Hp + "";
        coins.text = globalVar.Score + "";
        bullets.text = globalVar.Ammo + "";
    }
}
