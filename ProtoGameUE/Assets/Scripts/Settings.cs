using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings 
{
    public static KeyCode left
    {
        set => PlayerPrefs.SetInt("left", (int) value);
        get => (KeyCode) PlayerPrefs.GetInt("left", (int) KeyCode.A);
    }
    public static KeyCode up
    {
        set => PlayerPrefs.SetInt("up", (int)value);
        get => (KeyCode) PlayerPrefs.GetInt("up", (int)KeyCode.W);
    }
    public static KeyCode right
    {
        set => PlayerPrefs.SetInt("right", (int)value);
        get => (KeyCode) PlayerPrefs.GetInt("right", (int)KeyCode.D);
    }
    public static KeyCode down
    {
        set => PlayerPrefs.SetInt("down", (int)value);
        get => (KeyCode) PlayerPrefs.GetInt("down", (int)KeyCode.S);
    }
    public static KeyCode shoot
    {
        set => PlayerPrefs.SetInt("shoot", (int)value);
        get => (KeyCode) PlayerPrefs.GetInt("shoot", (int)KeyCode.Space);
    }
}
