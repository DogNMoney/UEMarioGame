using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public TextMeshProUGUI text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        { instance = this; }
    }

    public void ChangeScore()
    {
        score = score + 1;
        text.text = "SCORE: " + score.ToString();
    }
}
