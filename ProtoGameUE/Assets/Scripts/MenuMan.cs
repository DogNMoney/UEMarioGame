using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMan : MonoBehaviour
{

    // Use this for initialization
    public void qGame()
    {
        Application.Quit();

    }

    public void nGame()
    {
        SceneManager.LoadScene("TestLvl_Bartek");

    }
}
