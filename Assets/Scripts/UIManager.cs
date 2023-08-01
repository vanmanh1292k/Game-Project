using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager instance;

    public GameObject GameOver;

    private void Awake()
    {
        UIManager.instance = this;
        this.GameOver = GameObject.Find("GameOver");
        this.GameOver.SetActive(false);
    }
}
